using DeliverySystem.Application.Interfaces;


namespace DeliverySystem.Infrastructure.Services.DelivaryService
{
    class InStockDeliveryDateCalculator : IDeliveryDateCalculator
    {
        public DateTime Calculate(DateTime OrderTime)
        {

            if (OrderTime.Hour < 18)
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
