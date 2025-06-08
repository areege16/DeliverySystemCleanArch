using DeliverySystem.Application.Interfaces;


namespace DeliverySystem.Infrastructure.Services.DelivaryService
{
    class FreshFoodDeliveryDateCalculator: IDeliveryDateCalculator
    {
        public DateTime Calculate(DateTime OrderTime)
        {
            if (OrderTime.Hour < 12)
            {
                return OrderTime.Date;
            }
            else
            {
                return OrderTime.Date.AddDays(1);
            }
        }
    }
}
