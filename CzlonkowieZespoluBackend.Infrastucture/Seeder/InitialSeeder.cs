using CzlonkowieZespoluBackend.Infrastucture.DbProvider;
using CzlonkowieZespoluBackend.Domain.Interfaces;

namespace CzlonkowieZespoluBackend.Infrastucture.Seeder
{
    public class InitialSeeder
    {
        private readonly TeamMemberDbContext _dbContext;
        private readonly IRandomUserService _randomUserService;

        public InitialSeeder(TeamMemberDbContext dbContext, IRandomUserService randomUserService)
        {
            _dbContext = dbContext;
            _randomUserService = randomUserService;
        }

        public async Task Seed(int initialTeamMembersNumber)
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            {
                if (! _dbContext.TeamMembers.Any()) 
                {
                    var randomTeamMembers = await _randomUserService
                        .GetRandomTeamMembers(initialTeamMembersNumber);

                    await _dbContext.TeamMembers.AddRangeAsync(randomTeamMembers);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
