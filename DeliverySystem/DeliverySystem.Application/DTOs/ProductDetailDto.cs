
namespace DeliverySystem.Application.DTOs
{
  public class ProductDetailDto
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ProductType Type { get; set; }
    }
}
