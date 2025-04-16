using ServiceMesh.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ServiceMesh.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponID = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinimumAmount = 20,
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponID = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinimumAmount = 40,
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponID = 3,
                CouponCode = "30OFF",
                DiscountAmount = 30,
                MinimumAmount = 60,
            });

        }
    }
}
