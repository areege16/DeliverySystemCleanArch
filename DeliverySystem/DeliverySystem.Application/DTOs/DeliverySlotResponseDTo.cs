
namespace DeliverySystem.Application.DTOs
{
    public class DeliverySlotResponseDTo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsGreenSlot { get; set; }
    }
}
