namespace CzlonkowieZespoluBackend.Application.Dtos
{
    public class TeamMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhotoUrl { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDate { get; set; }
    }
}
