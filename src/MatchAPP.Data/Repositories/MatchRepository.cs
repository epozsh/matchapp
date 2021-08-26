using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Data.Repositories
{
    public class MatchRepository: GenericRepository<Match, MatchContext>, IMatchRepository
    {
        public MatchRepository(MatchContext context) : base(context)
        {

        }
    }
}
