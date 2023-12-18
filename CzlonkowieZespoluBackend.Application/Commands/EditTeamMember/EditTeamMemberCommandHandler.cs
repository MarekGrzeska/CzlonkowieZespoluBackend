using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.EditTeamMember
{
    public class EditTeamMemberCommandHandler : IRequestHandler<EditTeamMemberCommand>
    {
        private readonly ITeamMemberRepository _repository;

        public EditTeamMemberCommandHandler(ITeamMemberRepository repository) 
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await _repository.GetById(request.Id);
            teamMember.Name = request.Name;
            teamMember.Email = request.Email;
            teamMember.PhoneNumber = request.PhoneNumber;
            await _repository.Commit();
            return Unit.Value;
        }
    }
}
