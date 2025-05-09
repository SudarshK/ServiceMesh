namespace ServiceMesh.Services.Web.Models.DTO
{
    public class RegistrationRequestDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string? Role { get; set; }
        public string PhoneNumber { get; set; }
    }
}
