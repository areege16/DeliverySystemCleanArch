using DeliverySystem.Application.Interfaces;


namespace DeliverySystem.Infrastructure.Services.DelivaryService
{
    class ExternalDeliveryDateCalculator:IDeliveryDateCalculator
    {
        public DateTime Calculate(DateTime OrderTime)
        {
            //var externalDate = OrderTime.Date.AddDays(3);

            //while (externalDate.DayOfWeek == DayOfWeek.Saturday ||
            //       externalDate.DayOfWeek == DayOfWeek.Sunday ||
            //       externalDate.DayOfWeek == DayOfWeek.Monday)
            //{
            //    externalDate = externalDate.AddDays(1);
            //}
            return OrderTime.Date.AddDays(3);
        }
    }
}
