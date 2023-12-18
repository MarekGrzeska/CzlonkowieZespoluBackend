using CzlonkowieZespoluBackend.Application.Dtos;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.EditTeamMember
{
    public class EditTeamMemberCommand : EditTeamMemberDto, IRequest
    {
    }
}
