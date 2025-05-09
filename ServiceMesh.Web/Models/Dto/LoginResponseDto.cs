namespace ServiceMesh.Services.Web.Models.DTO
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
