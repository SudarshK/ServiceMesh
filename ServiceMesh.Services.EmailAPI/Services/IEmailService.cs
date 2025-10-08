using ServiceMesh.Services.EmailAPI.Model.DTO;

namespace ServiceMesh.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
    }
}
