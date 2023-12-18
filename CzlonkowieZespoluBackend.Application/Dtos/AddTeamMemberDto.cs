using Microsoft.AspNetCore.Http;

namespace CzlonkowieZespoluBackend.Application.Dtos
{
    public class AddTeamMemberDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? File { get; set; }
    }
}
