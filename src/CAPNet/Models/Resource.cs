using System;

namespace CAPNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DereferencedUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Digest { get; set; }
    }
}
