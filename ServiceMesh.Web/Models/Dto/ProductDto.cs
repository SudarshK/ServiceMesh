using ServiceMesh.Web.Utility;
using System.ComponentModel.DataAnnotations;

namespace ServiceMesh.Services.Web.Models.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageLocalPath { get; set; }
        [MaxFileSize(1)]
        [AllowedExtention(new string[] {".jpg", ".png"})]
        public IFormFile? Image {  get; set; }

        [Range(0, 100)]
        public int Count { get; set; } = 1;
    }
}
