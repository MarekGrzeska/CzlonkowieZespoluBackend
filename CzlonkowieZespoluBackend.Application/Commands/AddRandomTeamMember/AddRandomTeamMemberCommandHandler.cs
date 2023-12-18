using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Commands.AddRandomTeamMember
{
    public class AddRandomTeamMemberCommandHandler : IRequestHandler<AddRandomTeamMemberCommand>
    {
        private readonly ITeamMemberRepository _repository;
        private readonly IRandomUserService _randomUserService;

        public AddRandomTeamMemberCommandHandler(ITeamMemberRepository repository, IRandomUserService randomUserService)
        {
            _repository = repository; 
            _randomUserService = randomUserService;
        }

        public async Task<Unit> Handle(AddRandomTeamMemberCommand request, CancellationToken cancellationToken)
        {
            var teamMember = await _randomUserService.GetRandomTeamMembers(1);
            await _repository.AddTeamMember(teamMember.FirstOrDefault()!);
            return Unit.Value;
        }
    }
}
