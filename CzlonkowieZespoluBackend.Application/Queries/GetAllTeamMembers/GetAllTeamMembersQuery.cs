using CzlonkowieZespoluBackend.Application.Dtos;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Queries.GetAllTeamMembers
{
    public class GetAllTeamMembersQuery : IRequest<List<TeamMemberDto>>
    {
    }
}
