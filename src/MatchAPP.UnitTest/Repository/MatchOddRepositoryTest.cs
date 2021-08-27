using MatchAPP.Data;
using MatchAPP.Data.Repositories;
using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Enums;
using MatchAPP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace MatchAPP.UnitTest.Repository
{
    public class MatchOddRepositoryTest
    {
        private readonly IMatchOddRepository matchOddRepository;

        public MatchOddRepositoryTest()
        {
            var servicesFactory = new ServiceProviderFactory();

            servicesFactory.Services.AddTransient<IMatchOddRepository, MatchOddRepository>();

            var container = servicesFactory.GetServiceProvider();
            matchOddRepository = container.GetService<IMatchOddRepository>();

            var context = container.GetService<MatchContext>();

            context.Matches.Add(new Match()
            {
                Description = "OSFP-PAO",
                MatchDate = "19/03/2021",
                MatchTime = "12:00",
                TeamA = "OSFP",
                TeamB = "PAO",
                Sport = SportType.Football
            });

            context.MatchOdds.AddRange(
                new MatchOdd()
                {
                    MatchId = 1,
                    Specifier = "X",
                    Odd = 1.5
                },
                new MatchOdd()
                {
                    MatchId = 1,
                    Specifier = "X-2",
                    Odd = 1.4
                }
            );

            context.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var matchOdds = await matchOddRepository.GetAllAsync();

            Assert.NotEmpty(matchOdds);
        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            var match = await matchOddRepository.GetByIdAsync(1);

            Assert.Equal(1, match.ID);
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            var matchOdd = await matchOddRepository.AddAsync(new MatchOdd()
            {
                MatchId = 1,
                Specifier = "1-x",
                Odd = 1.3
            });

            Assert.True(matchOdd.ID > 0);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var matchOdd = await matchOddRepository.GetByIdAsync(1);
            matchOdd.Odd = 1.8;
            var matchOddUpdated = await matchOddRepository.UpdateAsync(matchOdd);

            Assert.Equal(1.8, matchOddUpdated.Odd);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var deletedMatchOdd = await matchOddRepository.DeleteAsync(2);
            var matchOdd = await matchOddRepository.GetByIdAsync(2);

            Assert.Null(matchOdd);
        }
    }
}
