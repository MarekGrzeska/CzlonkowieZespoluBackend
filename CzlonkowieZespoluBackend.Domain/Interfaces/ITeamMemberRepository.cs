using CzlonkowieZespoluBackend.Domain.Entities;

namespace CzlonkowieZespoluBackend.Domain.Interfaces
{
    public interface ITeamMemberRepository
    {
        Task<List<TeamMember>> GetAllTeamMembers();
        Task<TeamMember?> GetById(int id);
        Task AddTeamMember(TeamMember teamMember);
        Task Commit();
    }
}
