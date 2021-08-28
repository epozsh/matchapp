using AutoMapper;
using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchAPP.Domain.Services
{
    public class MatchRepositoryService : RepositoryService, IMatchRepositoryService
    {
        private readonly IMatchRepository _matchRepository;

        private string cacheKey = "Matches";
        public MatchRepositoryService(IMatchRepository matchRepository, IMapper mapper, IMemoryCache cache) : base(mapper, cache)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IList<MatchApiModel>> GetAllMatches()
        {
            var cachedMatches = await _memoryCache.GetOrCreateAsync<IList<MatchApiModel>>(cacheKey, async (c) =>
            {
                var matches = await _matchRepository.GetAllAsync(x => x.MatchOdds);

                if (matches.Any())
                {
                    c.SlidingExpiration = TimeSpan.FromMinutes(defaultSlideExpirationInMinutes);
                    return _mapper.Map<IList<MatchApiModel>>(matches); ;
                }
                return null;
            });
            return cachedMatches;
        }

        public async Task<MatchApiModel> GetMatchById(int id)
        {
            var cachedMatches = _memoryCache.Get<IList<MatchApiModel>>(cacheKey);
            var cachedMatch = cachedMatches?.FirstOrDefault(m => m.ID == id);

            if (cachedMatch == null)
            {
                var match = await _matchRepository.GetByIdAsync(id, x => x.MatchOdds);
                if (match != null)
                {
                    var mappedMatch = _mapper.Map<MatchApiModel>(match);

                    if (cachedMatches == null) cachedMatches = new List<MatchApiModel>();
                    cachedMatches.Add(mappedMatch);

                    _memoryCache.Set(cacheKey, cachedMatches, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(defaultSlideExpirationInMinutes)));
                    return mappedMatch;
                }
                return null;
            }

            return cachedMatch;
        }

        public async Task<MatchApiModel> AddMatch(MatchAddApiModel model)
        {
            var matchMapped = _mapper.Map<Match>(model);
            var match = await _matchRepository.AddAsync(matchMapped);

            // Update Cache with new match
            // return await GetMatchById(match.ID);

            // Reset Memory Cache
            _memoryCache.Remove(cacheKey);

            return _mapper.Map<MatchApiModel>(match);
        }

        public async Task<MatchApiModel> UpdateMatch(MatchApiModel model)
        {
            var matchMapped = _mapper.Map<Match>(model);
            var match = await _matchRepository.UpdateAsync(matchMapped);

            // Reset Memory Cache
            _memoryCache.Remove(cacheKey);

            return _mapper.Map<MatchApiModel>(match);
        }

        public async Task<bool> DeleteMatch(int id)
        {
            return await _matchRepository.DeleteAsync(id);
        }

    }
}
