using OfficeMonitoring.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OfficeMonitoring
{
    class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public Context() : base("EmployeeMonitoring")
        {

        }
    }
}
