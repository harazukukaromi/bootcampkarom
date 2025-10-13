using AutoMapper;
using PenjualanBarangApi.DTOs;
using PenjualanBarangApi.Models;

namespace PenjualanBarangApi.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Untuk POST (create)
            CreateMap<ProductCreateDTO, Product>();

            // Untuk PUT (update)
            CreateMap<ProductUpdateDTO, Product>();

            // Untuk GET (read)
            CreateMap<Product, ProductReadDTO>();
        }
    }
}