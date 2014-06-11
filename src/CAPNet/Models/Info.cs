using System;
using System.Collections.Generic;

namespace CAPNet
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
            this._parameters = new Dictionary<string, string>();
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

        private IDictionary<string, string> _parameters;

        public IDictionary<string, string> Parameters
        {
            get
            {
                return this._parameters;
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

    /// <summary>
    /// The code denoting the category of the subject event of the alert message.
    /// </summary>
    public enum Category
    {
        /// <summary>
        /// Geophysical (inc. landslide)
        /// </summary>
        Geo,
        /// <summary>
        /// 
        /// </summary>
        Met,
        /// <summary>
        /// 
        /// </summary>
        Safety,
        /// <summary>
        /// 
        /// </summary>
        Security,
        /// <summary>
        /// 
        /// </summary>
        Rescue,
        /// <summary>
        /// 
        /// </summary>
        Fire,
        /// <summary>
        /// 
        /// </summary>
        Health,
        /// <summary>
        /// 
        /// </summary>
        Env,
        /// <summary>
        /// 
        /// </summary>
        Transport,
        /// <summary>
        /// 
        /// </summary>
        Infra,
        /// <summary>
        /// 
        /// </summary>
        CBRNE,
        /// <summary>
        /// 
        /// </summary>
        Other
    }

    public enum Urgency
    {
        Immediate,
        Expected,
        Future,
        Past,
        Unknown
    }

    /// <summary>
    /// The code denoting the severity of the subject event of the alert message.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// Extraordinary threat to life or property.
        /// </summary>
        Extreme,
        /// <summary>
        /// Signifcant threat to life or property.
        /// </summary>
        Severe,
        /// <summary>
        /// Possible threat to life or property.
        /// </summary>
        Moderate,
        /// <summary>
        /// Minimal threat to life or property.
        /// </summary>
        Minor,
        /// <summary>
        /// Severity unknown.
        /// </summary>
        Unknown
    }

    public enum Certainty
    {
        Observed,
        Likely,
        Possible,
        Unlikely,
        Unknown
    }
}
