using AutoMapper;
using CzlonkowieZespoluBackend.Application.Dtos;
using CzlonkowieZespoluBackend.Domain.Interfaces;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Queries.GetRandomTeamMemberDto
{
    public class GetRandomTeamMemberDtoQueryHandler
        : IRequestHandler<GetRandomTeamMemberDtoQuery, RandomTeamMemberDto>
    {
        private readonly IRandomUserService _randomUserService;
        private readonly IMapper _mapper;
        
        public GetRandomTeamMemberDtoQueryHandler(IRandomUserService randomUserService, IMapper mapper) 
        {
            _randomUserService = randomUserService;
            _mapper = mapper;
        }

        public async Task<RandomTeamMemberDto> Handle(GetRandomTeamMemberDtoQuery request, CancellationToken cancellationToken)
        {
            var teamMember = await _randomUserService.GetRandomTeamMembers(1);
            var dto = _mapper.Map<RandomTeamMemberDto>(teamMember.FirstOrDefault());
            return dto;
        }
    }
}
