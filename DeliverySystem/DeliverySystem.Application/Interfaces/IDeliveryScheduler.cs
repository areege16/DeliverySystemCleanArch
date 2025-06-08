
using DeliverySystem.Application.DTOs;

namespace DeliverySystem.Application.Interfaces
{
    public interface IDeliveryScheduler
    {
        List<DeliverySlotResponseDTo> GetValidDeliverySlots(DeliverySlotRequestDTO request);//List<ProductDto> products, DateTime currentDateTime);
    }
}
