using DeliverySystem.Application.DTOs;
using DeliverySystem.Application.Interfaces;

namespace DeliverySystem.Infrastructure.Services.DelivaryService
{
    public class DeliveryScheduler: IDeliveryScheduler
    { 
        public List<DeliverySlotResponseDTo> GetValidDeliverySlots(DeliverySlotRequestDTO request)
        {
            var products = request.Products;
            var OrderTime = request.OrderTime;

            DateTime FirstDay = CalculateSlots(products, OrderTime);

            DateTime LastDay = FirstDay.AddDays(13);

            var deliverySlots = new List<DeliverySlotResponseDTo>();

            for (var date = FirstDay.Date; date <= LastDay.Date; date = date.AddDays(1))
            {
                bool ExternalProduct = products.Any(p => p.Type == ProductType.External);
                bool isMonday = date.DayOfWeek == DayOfWeek.Monday;

                if (IsWeekday(date)){

                if (!(ExternalProduct && isMonday)) { 

                for (int hour = 8; hour < 22; hour++)
                {
                    DateTime slotStart = date.AddHours(hour);
                    DateTime slotEnd = slotStart.AddHours(1);

                    if (slotStart > OrderTime) { 
                  
                    bool isGreen = IsGreenSlot(hour);

                    deliverySlots.Add(new DeliverySlotResponseDTo
                    {
                        StartTime = slotStart,
                        EndTime = slotEnd,
                        IsGreenSlot = isGreen
                    });
                }
            }
        }
    }
}
       return deliverySlots
                .OrderBy(slot => slot.StartTime.Date)
                .ThenByDescending(slot => slot.IsGreenSlot)
                .ThenBy(slot => slot.StartTime)
                .ToList();
        }

         DateTime CalculateSlots(List<ProductDto> products, DateTime OrderTime)
        {
            List<DateTime> Slots = new List<DateTime>();

            foreach (var product in products)
            {
                var calculator = DeliveryDateCalculatorFactory.GetCalculator(product.Type);
                Slots.Add(calculator.Calculate(OrderTime));
            }

            return Slots.Max(); //.OrderByDescending(x => x).First();

        }

         bool IsWeekday(DateTime date)
        {
            return date.DayOfWeek >= DayOfWeek.Monday && date.DayOfWeek <= DayOfWeek.Friday;
        }

         bool IsGreenSlot(int hour)
        {
            return (hour >= 13 && hour < 15) || (hour >= 20 && hour < 22);
        }
    }
}
