using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Models;

namespace ServiceMesh.Web.Service
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string productCode);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto productCode);
        Task<ResponseDto?> UpdateProductAsync(ProductDto productCode);
        Task<ResponseDto?> DeleteProductAsync(int id);
    }
}
