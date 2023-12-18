using CzlonkowieZespoluBackend.Application.Dtos;
using MediatR;

namespace CzlonkowieZespoluBackend.Application.Queries.GetTeamMemberById
{
    public class GetTeamMemberByIdQuery : IRequest<TeamMemberDto>
    {
        public int Id { get; set; }

        public GetTeamMemberByIdQuery(int id)
        {
            Id = id;
        }
    }
}
