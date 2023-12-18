using CzlonkowieZespoluBackend.Application.Dtos;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Queries.GetRandomTeamMemberDto
{
    public class GetRandomTeamMemberDtoQuery : IRequest<RandomTeamMemberDto>
    {
    }
}
