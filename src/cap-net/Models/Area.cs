using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP
{
    public class Area
    {
        public string Description { get; set; }
        public string Polygon { get; set; }
        public IDictionary<string, string> Geocodes { get; set; }
        public string Altitude { get; set; }
        public string Ceiling { get; set; }
    }
}
