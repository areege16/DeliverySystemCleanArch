
namespace DeliverySystem.Core.Entities
{
    class DeliverySlot
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsGreenSlot { get; set; }
    }
}
