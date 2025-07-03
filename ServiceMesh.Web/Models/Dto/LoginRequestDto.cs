using System.ComponentModel.DataAnnotations;

namespace ServiceMesh.Services.Web.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
