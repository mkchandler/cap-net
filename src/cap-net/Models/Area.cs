using System.Collections.Generic;

namespace CAP
{
    /// <summary>
    /// 
    /// </summary>
    public class Area
    {
        public Area()
        {
            _geocodes = new Dictionary<string, string>();
        }

        public string Description
        {
            get;
            set;
        }

        public string Polygon
        {
            get;
            set;
        }

        private IDictionary<string, string> _geocodes;

        public IDictionary<string, string> Geocodes
        {
            get { return _geocodes; }
        }

        public string Altitude
        {
            get;
            set;
        }

        public string Ceiling
        {
            get;
            set;
        }
    }
}
