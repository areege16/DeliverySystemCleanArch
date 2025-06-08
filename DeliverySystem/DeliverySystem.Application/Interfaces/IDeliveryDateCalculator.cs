
namespace DeliverySystem.Application.Interfaces
{
    public interface IDeliveryDateCalculator
    {
        DateTime Calculate(DateTime requestDate);
    }
}
