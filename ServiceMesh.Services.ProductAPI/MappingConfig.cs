using AutoMapper;
using ServiceMesh.Services.ProductAPI.Models;

namespace ServiceMesh.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Models.DTO.ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
