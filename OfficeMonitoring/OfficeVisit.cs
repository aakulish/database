using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMonitoring
{
    public class OfficeVisit
    {
        // The employee's name
        public string Employee { get; set; }

        // Date and time of entering the office room
        public DateTime Arrival { get; set; }

        // Date and time of leaving the office room
        public DateTime Departure { get; set; }
    }
}
