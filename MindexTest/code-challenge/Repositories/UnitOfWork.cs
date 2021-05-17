using challenge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeContext _employeeContext;

        public UnitOfWork(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void Complete()
        {
            _employeeContext.SaveChanges();
        }
    }
}
