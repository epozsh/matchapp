using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Domain.Services
{
    /// <summary>
    /// Wrapping all repositories.
    /// This will be used by client e.g. Api
    /// </summary>
    public class MatchRepositoryClientService : IMatchRepositoryClientService
    {
        public IMatchRepositoryService MatchRepositoryService { get; }
        public IMatchOddRepositoryService MatchOddRepositoryServiceService { get; }

        public MatchRepositoryClientService(IMatchRepositoryService matchRepository, IMatchOddRepositoryService matchOddRepositoryService)
        {
            MatchRepositoryService = matchRepository;
            MatchOddRepositoryServiceService = matchOddRepositoryService;
        }
    }
}
