using System;
using Microsoft.AspNetCore.Mvc;
using sample_netcore.Domain.Loggers;
using sample_netcore.Domain.Services;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Entities;

namespace sample_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IDishService services;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly INLogConfiguration logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishesController"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="logger">The logger.</param>
        public DishesController(IDishService services, INLogConfiguration logger)
        {
            this.services = services.ThrowIfNull(nameof(services));
            this.logger = logger.ThrowIfNull(nameof(logger));
        }

        /// <summary>
        /// Gets all dishes.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllDishes()
        {
            try
            {
                logger.Information("Execute get all employee.");
                var listDishes = services.GetAllDishes();
                return Ok(listDishes);
            }
            catch (Exception e)
            {
                logger.Error("ERROR IN GET DISHES: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

        /// <summary>
        /// Creates the dish.
        /// </summary>
        /// <param name="dish">The dish.</param>
        [HttpPost]
        public IActionResult CreateDish([FromBody]Dish dish)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                logger.Information("Execute insert dish.");

                var dishCreated = services.CreateDish(dish);

                return Created(Request.Path + dishCreated.Id, dishCreated);
            }
            catch (Exception e)
            {
                logger.Error("ERROR IN CREATE DISHES: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }


    }
}