using CzlonkowieZespoluBackend.Application.Dtos;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.AddNewTeamMember
{
    public class AddNewTeamMemberCommand : AddTeamMemberDto, IRequest
    {
    }
}
