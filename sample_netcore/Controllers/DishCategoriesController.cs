using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using sample_netcore.Domain.Loggers;
using sample_netcore.Domain.Services;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Entities;

namespace sample_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishCategoriesController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly INLogConfiguration logger;

        /// <summary>
        /// The service
        /// </summary>
        private readonly IDishService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DishCategoriesController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="logger">The logger.</param>
        public DishCategoriesController(IDishService service, INLogConfiguration logger)
        {
            this.logger = logger.ThrowIfNull(nameof(logger));
            this.service = service.ThrowIfNull(nameof(service));
        }

        /// <summary>
        /// Gets the dish categories.
        /// </summary>
        [HttpGet]
        public IEnumerable<DishCategory> GetDishCategories()
        {
            try
            {
                logger.Information("Execute query get all dish category.");
                return service.GetAllDishCategories();
            }
            catch(Exception e)
            {
                logger.Error("ERROR IN GET DISH CATEGORIES: " + e.Message + "Stacktrace: " + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Creates the dish category.
        /// </summary>
        /// <param name="dishCategory">The dish category.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDishCategory([FromBody]DishCategory dishCategory)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                logger.Information("Execute insert dish category");

                var dishCategoryCreated = service.CreateDishCategory(dishCategory);

                return Created(Request.Path + dishCategoryCreated.Id, dishCategoryCreated);
            }
            catch (Exception e)
            {
                logger.Error("ERROR IN CREATE DISH CATEGORY: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates the dish category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="dishCategory">The dish category.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateDishCategory(Guid id, [FromBody]DishCategory dishCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                logger.Information("Execute update dish category.");
                var dishCategoryUpdated = service.UpdateDishCategory(id,dishCategory);

                return Ok(dishCategoryUpdated);
            }
            catch (Exception e)
            {
                logger.Error("ERROR IN UPDATE DISH CATEGORY: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets the dishes by category.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("GetDishesByCategory/{id}")]
        public IActionResult GetDishesByCategory(Guid id)
        {
            try
            {
                logger.Information("Execute get dishes by category.");
                var listDish = service.GetAllDishesByCategoryId(id);
                return Ok(listDish);
            }
            catch(Exception e)
            {
                logger.Error("ERROR IN GET DISH BY CATEGORY: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

        [HttpGet("FindCategoryByName/{name}")]
        public IActionResult FindCategoryByName(string name)
        {
            var x = service.FindDishCategoryByName(name);
            return Ok(x);
        }
    }
}