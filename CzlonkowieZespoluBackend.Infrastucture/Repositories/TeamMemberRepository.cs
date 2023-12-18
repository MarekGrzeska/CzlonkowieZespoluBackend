using CzlonkowieZespoluBackend.Domain.Entities;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using CzlonkowieZespoluBackend.Infrastucture.DbProvider;
using Microsoft.EntityFrameworkCore;

namespace CzlonkowieZespoluBackend.Infrastucture.Repositories
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly TeamMemberDbContext _dbContext;

        public TeamMemberRepository(TeamMemberDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTeamMember(TeamMember teamMember)
        {
            await _dbContext.TeamMembers.AddAsync(teamMember);
            await Commit();
        }

        public async Task<TeamMember?> GetById(int id)
        {
            return await _dbContext.TeamMembers.FirstOrDefaultAsync(tm => tm.Id == id);
        }

        public async Task<List<TeamMember>> GetAllTeamMembers()
        {
            return await _dbContext.TeamMembers.OrderBy(m => m.CreatedDate).ToListAsync();
        }

     
    }
}