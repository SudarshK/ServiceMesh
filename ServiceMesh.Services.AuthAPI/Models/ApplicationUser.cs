using Microsoft.AspNetCore.Identity;

namespace ServiceMesh.Services.AuthAPI.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name {  get; set; }

    }
}
