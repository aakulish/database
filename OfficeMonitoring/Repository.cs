using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace OfficeMonitoring
{
    public class Repository
    {
        List<OfficeVisit> _visits;

        public List<OfficeVisit> Visits
        {
            get
            {
                return _visits;
            }
        }

        public Repository()
        {
            StreamReader sr = new StreamReader("../../data.txt");
            _visits = new List<OfficeVisit>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var words = line.Split(' ');
                _visits.Add(new OfficeVisit
                {
                    Arrival = DateTime.ParseExact(words[0] + " " + words[1],
                        "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    Departure = DateTime.ParseExact(words[0] + " " + words[2],
                        "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    Employee = words[3]                    
                });
            }

            sr.Close();
        }
    }
}
