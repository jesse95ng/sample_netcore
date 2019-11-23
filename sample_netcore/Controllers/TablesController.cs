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
    public class TablesController : ControllerBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly ITableService service;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly INLogConfiguration logger;

        public TablesController(ITableService service, INLogConfiguration logger)
        {
            this.service = service.ThrowIfNull(nameof(service));
            this.logger = logger.ThrowIfNull(nameof(logger));
        }

        /// <summary>
        /// Gets all tables.
        /// </summary>
        [HttpGet]
        public IEnumerable<Table> GetAllTables()
        {
            try
            {
                logger.Information("Execute query get all table.");
                return service.GetAllTable();
            }
            catch (Exception e)
            {
                logger.Error("GET TABLE: " + e.Message + "Stacktrace: " + e.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Gets the table by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpGet("{id}")]
        public IActionResult GetTableById(Guid id)
        {
            try
            {
                logger.Information("Execute query get table by id.");
                var table = service.GetTableById(id);
                return Ok(table);
            }
            catch (Exception e)
            {
                logger.Error("GET TABLE BY ID: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateTable([FromBody]Table table)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                logger.Information("Execute insert table.");
                var tableCreated = service.CreateTable(table);

                return Created(Request.Path + tableCreated.Id, tableCreated);
            }
            catch (Exception e)
            {
                logger.Error("ERROR IN CREATE TABLE: " + e.Message + "Stacktrace: " + e.StackTrace);
                return BadRequest();
            }
        }
    }
}