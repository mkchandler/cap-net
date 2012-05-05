using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP
{
    public class Info
    {
        private string _language;

        public string Language
        {
            get { return String.IsNullOrWhiteSpace(_language) ? "en-US" : _language; }
            set { _language = value; }
        }
    }
}
