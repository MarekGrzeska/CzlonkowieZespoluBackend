namespace CzlonkowieZespoluBackend.Application.Dtos
{
    public class EditTeamMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
