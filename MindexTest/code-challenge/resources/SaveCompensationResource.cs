using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.resources
{
    /// <summary>
    /// In this exercise we're making all three components of a compensation mandatory.
    /// We could allow the Effective Date to be empty and default it to DateTime.MinDate.
    /// Really the salary could default to 0.0M too for that matter.
    /// It wouldn't make a lot sense business wise to say someone's been around forever
    /// making no money.  teh caller can pass that as legit if they want to.
    /// </summary>
    public class SaveCompensationResource
    {
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }

    }
}
