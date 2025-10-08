namespace ServiceMesh.Services.OrderAPI.Models.DTO
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<OrderDetailsDto>? CartDetails { get; set; }
    }
}
