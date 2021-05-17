using challenge.Data;
using challenge.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;
        
        public CompensationRepository(EmployeeContext employeeContext, ILogger<ICompensationRepository> logger)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Compensation GetById(String id)
        {
            Compensation comp = _employeeContext.Compensations.SingleOrDefault(c => c.EmployeeId == id);
            return comp;
        }

        public Compensation Add(Compensation comp)
        {
            if (!string.IsNullOrWhiteSpace(comp.EmployeeId))
            {
                if (_employeeContext.Compensations.Find(comp.EmployeeId) == null)
                {
                    if (_employeeContext.Employees.Find(comp.EmployeeId) != null)
                    {
                        _employeeContext.Compensations.Add(comp);
                        return comp;
                    }
                }
            }
            return null;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
