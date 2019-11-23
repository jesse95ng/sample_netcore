using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using sample_netcore.Domain.Validation;
using sample_netcore.Models.Context;
using sample_netcore.Models.Dto;
using sample_netcore.Models.Entities;

namespace sample_netcore.Domain.Services
{
    /// <summary>
    /// EmployeeService
    /// </summary>
    /// <seealso cref="sample_netcore.Services.IEmployeeService" />
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly SampleDbContext _dbContext;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EmployeeService(SampleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext.ThrowIfNull(nameof(dbContext));
            _mapper = mapper.ThrowIfNull(nameof(mapper));
        }

        /// <summary>
        /// Creates the employee.
        /// </summary>
        public EmployeeDto CreateEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                var emplViewItem = _mapper.Map<EmployeeDto>(employee);
                emplViewItem.EmpId = employee.Id;
                return emplViewItem;
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Finds the employee.
        /// </summary>
        /// <param name="id">The employee Id.</param>
        public Employee FindEmployee(Guid id)
        {
            try
            {
                return _dbContext.Employees
                .FirstOrDefault(e => e.Id == id);
            }
            catch
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Gets all employees.
        /// </summary>
        public IEnumerable<Employee> GetAllEmployees()
        {   
            try
            {
                return _dbContext.Employees
                .OrderBy(e => e.Id)
                .ToList();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public EmployeeDto UpdateEmployee(Guid id, EmployeeDto empl)
        {
            try
            {
                var emplIndDb = _dbContext.Employees.SingleOrDefault(e => e.Id == id);
                if (emplIndDb == null)
                {
                    return null;
                }
                _mapper.Map(empl, emplIndDb);
                empl.EmpId = emplIndDb.Id;
                _dbContext.SaveChanges();
                return empl;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
