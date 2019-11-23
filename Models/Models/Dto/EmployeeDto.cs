using System;

namespace sample_netcore.Models.Dto
{
    public class EmployeeDto
    {
        public Guid EmpId { get; set; }

        public string EmpName { get; set; }

        public DateTime? EmpBirthDate { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }
    }
}
