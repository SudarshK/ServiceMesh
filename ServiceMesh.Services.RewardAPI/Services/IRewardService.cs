using ServiceMesh.Services.RewardAPI;
using ServiceMesh.Services.RewardAPI.Dto;

namespace ServiceMesh.Services.RewardAPI.Services
{
    public interface IRewardService
    {
        Task UpdateRewards(RewardMessage rewardMessage);
    }
}
