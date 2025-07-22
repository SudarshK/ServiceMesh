using AutoMapper;
using ServiceMesh.Services.ShoppingCartAPI.Models;
using ServiceMesh.Services.ShoppingCartAPI.Models.DTO;

namespace ServiceMesh.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader,CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails,CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
