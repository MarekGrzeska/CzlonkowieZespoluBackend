using CzlonkowieZespoluBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CzlonkowieZespoluBackend.Infrastucture.DbProvider
{
    public class TeamMemberDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }

        public TeamMemberDbContext(DbContextOptions<TeamMemberDbContext> options) : base(options) {}
    }
}
