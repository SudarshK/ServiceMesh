using ServiceMesh.Services.EmailAPI.Model.DTO;

namespace ServiceMesh.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        //Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardMessage rewardsDto);
    }
}
