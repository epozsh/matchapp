using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatchAPP.Domain.Services
{
    public interface IMatchOddRepositoryService
    {
        Task<IList<MatchOddApiModel>> GetAllMatchOdds(); // Get All Odds
        Task<MatchOddApiModel> GetMatchOddById(int id);
        Task<MatchOddApiModel> AddMatchOdd(MatchOddAddApiModel model);
        Task<MatchOddApiModel> UpdateMatchOdd(MatchOddUpdateApiModel model);
        Task<bool> DeleteMatchOdd(int id);
    }
}
