using ServiceMesh.Services.RewardAPI;
using ServiceMesh.Services.RewardAPI.Dto;

namespace ServiceMesh.Services.EmailAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardMessage rewardMessage);
    }
}
