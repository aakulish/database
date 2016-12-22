using OfficeMonitoring.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace OfficeMonitoring
{
    class Program
    {
        static void MoveToDB()
        {
            using (var context = new Context())
            {
                var r = new Repository();
                foreach (var v in r.Visits)
                {
                    var employee = new Employee { Name = v.Employee };
                    context.Employees.AddOrUpdate(e => e.Name, employee);
                    context.SaveChanges();

                    var visit = new Visit
                    {
                        Employee = context.Employees.Single(e => e.Name == v.Employee),
                        Arrival = v.Arrival,
                        Departure = v.Departure,
                    };
                    context.Visits.Add(visit);
                    context.SaveChanges();
                }
            }
                
        }

        static void GetAverageTimes()
        {
            using (var context = new Context())
            {
                var result = context.Visits.GroupBy(v => v.Employee)
                    .AsEnumerable()    // Required to process datetime operations in the application, db cannot do it
                    .Select(g => new { Employee = g.Key.Name, AverageTime = g.Average(item => (item.Departure - item.Arrival).TotalMinutes) });
                foreach (var item in result)
                {
                    Console.WriteLine("{0} - {1:f2} min", item.Employee, item.AverageTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Uncomment and run once
            // MoveToDB();
            GetAverageTimes();

        }
    }
}
