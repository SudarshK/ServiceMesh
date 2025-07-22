using ServiceMesh.Services.ShoppingCartAPI.Models.DTO;

namespace ServiceMesh.Services.ShoppingCartAPI.Service.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
