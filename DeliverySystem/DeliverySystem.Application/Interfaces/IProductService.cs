
using DeliverySystem.Application.DTOs;

namespace DeliverySystem.Application.Interfaces
{
   public interface IProductService
    {
        Task<List<ProductDetailDto>> GetAllProductsAsync();
    }
}
