using AutoMapper;
using DeliverySystem.Application.DTOs;
using DeliverySystem.Application.Interfaces;
using DeliverySystem.Core.Entities;
using DeliverySystem.Core.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.Infrastructure.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<List<ProductDetailDto>> GetAllProductsAsync()
        {
            var product = await repository.GetAll().ToListAsync();
            return mapper.Map<List<ProductDetailDto>>(product);



            //return product.Select(p => new ProductDetailDto
            //{    
            //    Name = p.Name,
            //    Price=p.Price,
            //    Type=p.Type, 
            //}).ToList();

        }
    }
}
