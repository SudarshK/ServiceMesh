using Microsoft.EntityFrameworkCore;
using ServiceMesh.Services.RewardAPI.Data;
using ServiceMesh.Services.RewardAPI.Dto;
using ServiceMesh.Services.RewardAPI.Models;
using System.Text;

namespace ServiceMesh.Services.RewardAPI.Services
{
    public class RewardService : IRewardService
    {
        private DbContextOptions<AppDbContext> _dbOptions;

        public RewardService(DbContextOptions<AppDbContext> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public async Task UpdateRewards(RewardMessage rewardMessage)
        {
            try
            {
                Rewards rewards = new()
                {
                    OrderId = rewardMessage.OrderId,
                    RewardsActivity = rewardMessage.RewardsActivity,
                    UserId = rewardMessage.UserId,
                    RewardsDate = DateTime.Now,
                };
                await using var db = new AppDbContext(_dbOptions);
                await db.Rewards.AddAsync(rewards);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // log exception
            }
        }
    }
}
