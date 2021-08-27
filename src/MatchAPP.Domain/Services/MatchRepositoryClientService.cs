using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Domain.Services
{
    /// <summary>
    /// This will be used by client e.g. Api
    /// </summary>
    public class MatchRepositoryClientService
    {
        public readonly IMatchRepositoryService MatchRepositoryService;
        public readonly IMatchOddRepositoryService MatchOddRepositoryServiceService;

        public MatchRepositoryClientService(IMatchRepositoryService matchRepository, IMatchOddRepositoryService matchOddRepositoryService)
        {
            MatchRepositoryService = matchRepository;
            MatchOddRepositoryServiceService = matchOddRepositoryService;
        }

    }
}
