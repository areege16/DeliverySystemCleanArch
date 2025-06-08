using AutoMapper;
using DeliverySystem.Application.DTOs;
using DeliverySystem.Core.Entities;

namespace DeliverySystem.Application.Mappings
{
   public class productProfile:Profile
    {
        public productProfile()
        {
            CreateMap<Product, ProductDetailDto>().ReverseMap();
        }
    }
}
