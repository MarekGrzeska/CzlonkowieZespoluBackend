using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.ChangeTeamMemberStatus
{
    public class ChangeTeamMemberStatusCommand : IRequest
    {
        public int Id { get; set; }

        public ChangeTeamMemberStatusCommand(int id)
        {
            Id = id;
        }
    }
}