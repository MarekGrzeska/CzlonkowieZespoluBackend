using AutoMapper;
using CzlonkowieZespoluBackend.Application.Dtos;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Queries.GetTeamMemberById
{
    public class GetTeamMemberByIdQueryHandler : IRequestHandler<GetTeamMemberByIdQuery, TeamMemberDto>
    {
        private readonly ITeamMemberRepository _repository;
        private readonly IMapper _mapper;

        public GetTeamMemberByIdQueryHandler(ITeamMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TeamMemberDto> Handle(GetTeamMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var teamMember = await _repository.GetById(request.Id);
            var dto = _mapper.Map<TeamMemberDto>(teamMember);
            return dto;
        }
    }
}
