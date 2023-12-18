using CzlonkowieZespoluBackend.Domain.Entities;

namespace CzlonkowieZespoluBackend.Domain.Interfaces
{
    public interface IRandomUserService
    {
        Task<List<TeamMember>> GetRandomTeamMembers(int num);
    }
}
