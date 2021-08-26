using MatchAPP.Data;
using MatchAPP.Data.Repositories;
using MatchAPP.Domain.Entities;
using MatchAPP.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace MatchAPP.UnitTest.Repository
{
    public class MatchRepositoryTest
    {
        private readonly IMatchRepository matchRepository;

        public MatchRepositoryTest()
        {
            var servicesFactory = new ServiceProviderFactory();

            servicesFactory.Services.AddTransient<IMatchRepository, MatchRepository>();

            var container = servicesFactory.GetServiceProvider();
            matchRepository = container.GetService<IMatchRepository>();

            var context = container.GetService<MatchContext>();

            context.Matches.AddRange(new Match()
            {
                Description = "OSFP-PAO",
                MatchDate = "19/03/2021",
                MatchTime = "12:00",
                TeamA = "OSFP",
                TeamB = "PAO",
                Sport = SportType.Football
            },
            new Match()
            {
                Description = "PAO-OSFP",
                MatchDate = "19/07/2021",
                MatchTime = "17:00",
                TeamA = "PAO",
                TeamB = "OSFP",
                Sport = SportType.Football
            });

            context.SaveChanges();
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var matches = await matchRepository.GetAllAsync();

            Assert.NotEmpty(matches);
        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            var match = await matchRepository.GetByIdAsync(1);

            Assert.Equal(1, match.ID);
        }

        [Fact]
        public async Task AddAsyncTest()
        {
            var match = await matchRepository.AddAsync(new Match()
            {
                Description = "OSFP-PAO",
                MatchDate = "19/03/2021",
                MatchTime = "12:00",
                TeamA = "OSFP",
                TeamB = "PAO",
                Sport = SportType.Football
            });

            Assert.True(match.ID > 0);
        }

        [Fact]
        public async Task UpdateAsyncTest()
        {
            var match = await matchRepository.GetByIdAsync(1);
            match.Sport = SportType.Basketball;
            var matchUpdated = await matchRepository.UpdateAsync(match);

            Assert.Equal(SportType.Basketball, matchUpdated.Sport);
        }

        [Fact]
        public async Task DeleteAsyncTest()
        {
            var match = await matchRepository.DeleteAsync(2);
            var deletedMatch = await matchRepository.GetByIdAsync(2);

            Assert.Null(deletedMatch);
        }
    }
}
