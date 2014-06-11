using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 
        /// </summary>
        public Area()
        {
            _geocodes = new Dictionary<string, string>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Polygon { get; set; }

        private IDictionary<string, string> _geocodes;

        /// <summary>
        /// 
        /// </summary>
        public IDictionary<string, string> Geocodes
        {
            get { return _geocodes; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Altitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Ceiling { get; set; }
    }
}
