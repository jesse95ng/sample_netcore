using System;
using System.Collections.Generic;

namespace sample_netcore.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string EmpName { get; set; }

        public DateTime? EmpBirthDate { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
