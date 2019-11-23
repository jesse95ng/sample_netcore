using sample_netcore.Models.Dto;
using sample_netcore.Models.Entities;
using System;
using System.Collections.Generic;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// EmployeeService interface
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Gets all employees.
        /// </summary>
        IEnumerable<Employee> GetAllEmployees();

        /// <summary>
        /// Finds the employee.
        /// </summary>
        /// <param name="id">The employee Id.</param>
        Employee FindEmployee(Guid id);

        /// <summary>
        /// Creates the employee.
        /// </summary>
        /// <param name="empl">The employee.</param>
        EmployeeDto CreateEmployee(Employee employee);

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="id">The employee id.</param>
        /// <param name="empl">The employee.</param>
        EmployeeDto UpdateEmployee(Guid id, EmployeeDto empl);
    }
}
