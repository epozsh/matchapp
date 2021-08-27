using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Domain.Services
{
    /// <summary>
    /// This will be used by client e.g. Api
    /// </summary>
    public interface IMatchRepositoryClientService
    {
        IMatchRepositoryService MatchRepositoryService { get; }
        IMatchOddRepositoryService MatchOddRepositoryServiceService { get; }

    }
}
