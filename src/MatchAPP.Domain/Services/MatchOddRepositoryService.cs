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
    public class MatchOddRepositoryService : RepositoryService, IMatchOddRepositoryService
    {
        private readonly IMatchOddRepository _matchOddRepository;

        private string cacheKey = "MatchesOdds";
        public MatchOddRepositoryService(IMatchOddRepository matchOddRepository, IMapper mapper, IMemoryCache cache) : base(mapper, cache)
        {
            _matchOddRepository = matchOddRepository;
        }

        public async Task<IList<MatchOddApiModel>> GetAllMatchOdds()
        {
            var cachedMatchesOdds = await _memoryCache.GetOrCreateAsync<IList<MatchOddApiModel>>(cacheKey, async (c) =>
            {
                var matchesOdds = await _matchOddRepository.GetAllAsync(x => x.Match);

                if (matchesOdds.Any())
                {
                    c.SlidingExpiration = TimeSpan.FromMinutes(defaultSlideExpirationInMinutes);
                    return _mapper.Map<IList<MatchOddApiModel>>(matchesOdds);
                }
                return null;
            });
            return cachedMatchesOdds;
        }

        public async Task<MatchOddApiModel> GetMatchOddById(int id)
        {
            var cachedMatchesOdds = _memoryCache.Get<IList<MatchOddApiModel>>(cacheKey);
            var cachedMatchOdd = cachedMatchesOdds?.FirstOrDefault(m => m.ID == id);

            if (cachedMatchOdd == null)
            {
                var match = await _matchOddRepository.GetByIdAsync(id, x => x.Match);
                if (match != null)
                {
                    var mappedMatchOdd = _mapper.Map<MatchOddApiModel>(match);

                    if (cachedMatchesOdds == null) cachedMatchesOdds = new List<MatchOddApiModel>();
                    cachedMatchesOdds.Add(mappedMatchOdd);

                    _memoryCache.Set(cacheKey, mappedMatchOdd, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(defaultSlideExpirationInMinutes)));
                    return mappedMatchOdd;
                }
                return null;
            }

            return cachedMatchOdd;
        }

        public async Task<MatchOddApiModel> AddMatchOdd(MatchOddAddApiModel model)
        {
            var matchOddMapped = _mapper.Map<MatchOdd>(model);
            var matchOdd = await _matchOddRepository.AddAsync(matchOddMapped);

            // Update Cache with new match
            // return await GetMatchById(match.ID);

            // Reset Memory Cache
            _memoryCache.Remove(cacheKey);

            return _mapper.Map<MatchOddApiModel>(matchOdd);
        }

        public async Task<MatchOddApiModel> UpdateMatchOdd(MatchOddUpdateApiModel model)
        {
            var matchOddMapped = _mapper.Map<MatchOdd>(model);
            var matchOdd = await _matchOddRepository.UpdateAsync(matchOddMapped);

            // Reset Memory Cache
            _memoryCache.Remove(cacheKey);

            return _mapper.Map<MatchOddApiModel>(matchOdd);
        }

        public async Task<bool> DeleteMatchOdd(int id)
        {
            return await _matchOddRepository.DeleteAsync(id);
        }

    }
}
