using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP
{
    public class Resource
    {
        public string Description { get; set; }
        public string MimeType { get; set; }
        public int? Size { get; set; }
        public string Uri { get; set; }
        public string DereferencedUri { get; set; }
        public string Digest { get; set; }
    }
}
