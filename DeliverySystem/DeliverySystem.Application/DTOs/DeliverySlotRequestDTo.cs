
namespace DeliverySystem.Application.DTOs
{
   public class DeliverySlotRequestDTO
    {
        public List<ProductDto> Products { get; set; }
        public DateTime OrderTime { get; set; }

    }

}
