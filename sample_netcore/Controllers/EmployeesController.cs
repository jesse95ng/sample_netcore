using System;
using Microsoft.AspNetCore.Mvc;
using sample_netcore.Domain.Loggers;
using sample_netcore.Domain.Services;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Dto;
using sample_netcore.Models.Entities;

namespace sample_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly INLogConfiguration _logger;

        public EmployeesController(IEmployeeService service, INLogConfiguration logger)
        {
            _service = service.ThrowIfNull(nameof(service));
            _logger = logger.ThrowIfNull(nameof(logger));
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var listEmployee = _service.GetAllEmployees();
            return Ok(listEmployee);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody]Employee emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdEmployee = _service.CreateEmployee(emp);
            return Created(Request.Path + createdEmployee.EmpId, createdEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(Guid id, [FromBody]EmployeeDto emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var updatedEmployee = _service.UpdateEmployee(id, emp);
            return Ok(updatedEmployee);
        }
    }
}