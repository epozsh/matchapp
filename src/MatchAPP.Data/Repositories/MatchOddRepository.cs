using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchAPP.Data.Repositories
{
    public class MatchOddRepository: GenericRepository<MatchOdd, MatchContext>, IMatchOddRepository
    {
        public MatchOddRepository(MatchContext context) : base(context)
        {

        }
    }
}
