using MatchAPP.Domain.ApiModels;
using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatchAPP.Domain.Services
{
    public interface IMatchRepositoryService
    {
        Task<IList<MatchApiModel>> GetAllMatches();
        Task<MatchApiModel> GetMatchById(int id);
        Task<MatchApiModel> AddMatch(MatchAddApiModel model);
        Task<MatchApiModel> UpdateMatch(MatchApiModel model);
        Task<bool> DeleteMatch(int id);
    }
}
