using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.ChangeTeamMemberStatus
{
    public class ChangeTeamMemberStatusCommandHandler : IRequestHandler<ChangeTeamMemberStatusCommand>
    {
        private readonly ITeamMemberRepository _repository;

        public ChangeTeamMemberStatusCommandHandler(ITeamMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangeTeamMemberStatusCommand request, CancellationToken cancellationToken)
        {
            var teamTember = await _repository.GetById(request.Id);
            if (teamTember != null) 
            {
                teamTember.IsActive = !teamTember.IsActive;
                await _repository.Commit();
            }
            return Unit.Value;
        }
    }
}
