using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeMonitoring.Entities
{
    class Visit
    {
        public int Id { get; set; }
        [Required]
        public DateTime Arrival { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public Employee Employee { get; set; }
    }
}
