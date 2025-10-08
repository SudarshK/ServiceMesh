using ServiceMesh.Services.OrderAPI.Models.DTO;

namespace ServiceMesh.Services.OrderAPI.Service.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
