using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class EmployeeRespository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRespository(ILogger<IEmployeeRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid().ToString();
            _employeeContext.Employees.Add(employee);
            return employee;
        }

        public Employee GetById(string id)
        {
            Employee emp = _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
            LoopList();
            return _employeeContext.Employees.SingleOrDefault(e => e.EmployeeId == id);
        }

        /// <summary>
        /// LoopList - does nothing but wastes time.  Perhaps a wait() will suffice or turn it async
        /// On my system this somehow causes the direct reports list in the Employee item to consistenly 
        /// become populated.  Without it they are consistently not populated.  This requires research
        /// and understanding as this is clearly not a viable option.  It jus thappens to work... for now.
        /// </summary>
        private void LoopList()
        {
            foreach (Employee e in _employeeContext.Employees)
            {
            }
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }

        public Employee Remove(Employee employee)
        {
            return _employeeContext.Remove(employee).Entity;
        }
    }
}
