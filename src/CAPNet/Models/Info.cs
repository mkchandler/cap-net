using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message.
    /// </summary>
    public class Info
    {
        /// <summary>
        /// 
        /// </summary>
        public Info()
        {
            _parameters = new List<Parameter>();
            _categories = new List<Category>();
            _resources = new List<Resource>();
            _areas = new List<Area>();
        }

        private string _language;

        /// <summary>
        /// Gets or sets the code denoting the language of the info sub-element of the alert message.
        /// </summary>
        public string Language
        {
            get { return String.IsNullOrWhiteSpace(_language) ? "en-US" : _language; }
            set { _language = value; }
        }

        private ICollection<Category> _categories;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Category> Categories
        {
            get
            {
                return _categories;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Urgency Urgency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Severity? Severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Certainty Certainty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EventCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Effective { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Onset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset Expires { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Instruction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Web { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Contact { get; set; }

        private ICollection<Parameter> _parameters;

        /// <summary>
        /// System-specific additional parameters associated
        /// with the alert message (OPTIONAL)
        /// </summary>
        public ICollection<Parameter> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        private ICollection<Resource> _resources;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Resource> Resources
        {
            get { return _resources; }
        }

        private ICollection<Area> _areas;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Area> Areas
        {
            get { return _areas; }
        }
    }
}
