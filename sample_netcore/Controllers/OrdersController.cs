
using Microsoft.AspNetCore.Mvc;
using sample_netcore.Domain.Loggers;
using sample_netcore.Domain.Services;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Entities;
using System;

namespace sample_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly INLogConfiguration _logger;

        private readonly IBillingService _service;

        public OrdersController(IBillingService service, INLogConfiguration logger)
        {
            _logger = logger.ThrowIfNull(nameof(logger));
            _service = service.ThrowIfNull(nameof(service));
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody]Order order)
        {
            try
            {
                _service.CreateOrder(order);
                //_service.GetRevenueByDay();
                return Ok(order);
            }
            catch(Exception e)
            {
                _logger.Error("ERROR IN GET ORDER: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

    }
}