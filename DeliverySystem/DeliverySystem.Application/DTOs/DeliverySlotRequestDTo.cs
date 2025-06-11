
namespace DeliverySystem.Application.DTOs
{
   public class DeliverySlotRequestDTO
    {
       
        public List<ProductDto> Products { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 14;
        public DateTime OrderTime { get; set; }

       

    }

}
