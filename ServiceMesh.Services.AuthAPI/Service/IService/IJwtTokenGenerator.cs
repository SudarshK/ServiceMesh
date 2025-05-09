using ServiceMesh.Services.AuthAPI.Models;

namespace ServiceMesh.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
