using DeliverySystem.Application.Interfaces;


namespace DeliverySystem.Infrastructure.Services.DelivaryService
{
    class DeliveryDateCalculatorFactory
    {
        public static IDeliveryDateCalculator GetCalculator(ProductType type)
        {
            switch (type)
            {
                case ProductType.InStock:
                    return new InStockDeliveryDateCalculator();
                case ProductType.FreshFood:
                    return new FreshFoodDeliveryDateCalculator();
                case ProductType.External:
                    return new ExternalDeliveryDateCalculator();
                default:
                    throw new Exception("Unknown type");
            }
        }
    }
}
