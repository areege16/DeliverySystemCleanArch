using DeliverySystem.Application.DTOs;
using DeliverySystem.Application.Interfaces;
using DeliverySystem.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryScheduler deliveryScheduler;

        public DeliveryController(IDeliveryScheduler deliveryScheduler)
        {
            this.deliveryScheduler = deliveryScheduler;
        }

        [HttpPost("slots")]
        public ActionResult<List<DeliverySlotResponseDTo>> GetDeliverySlots([FromBody] DeliverySlotRequestDTO request)
        {
            if (request == null || request.Products == null || !request.Products.Any() )
                return BadRequest("Product list is required ");

            var slots = deliveryScheduler.GetValidDeliverySlots(request);//request.Products, request.OrderTime);

            return Ok(slots);
        }
    }
}
