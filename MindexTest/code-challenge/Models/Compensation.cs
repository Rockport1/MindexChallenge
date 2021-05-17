using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace challenge.Models
{
    /// <summary>
    /// This class simply holds an employee's salary and the date the salary and the effectuation date of the salary.
    /// </summary>
    public class Compensation
    {
        [Key]
        public String EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
