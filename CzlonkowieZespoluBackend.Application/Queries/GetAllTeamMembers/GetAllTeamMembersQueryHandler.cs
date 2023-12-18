using AutoMapper;
using CzlonkowieZespoluBackend.Application.Dtos;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;
using System.Numerics;

namespace CzlonkowieZespoluBackend.Application.Queries.GetAllTeamMembers
{
    public class GetAllTeamMembersQueryHandler : IRequestHandler<GetAllTeamMembersQuery, List<TeamMemberDto>>
    {
        private readonly ITeamMemberRepository _repository;
        private readonly IMapper _mapper;

        public GetAllTeamMembersQueryHandler(ITeamMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TeamMemberDto>> Handle(GetAllTeamMembersQuery request, CancellationToken cancellationToken)
        {
            var teamMembers = await _repository.GetAllTeamMembers();
            var teamMembersDto = _mapper.Map<List<TeamMemberDto>>(teamMembers);
            for (int i=0; i<teamMembers.Count(); i++)
            {
                teamMembersDto[i].CreatedDate = teamMembers[i].CreatedDate.ToShortDateString();
            }
            return teamMembersDto;
        }
    }
}
