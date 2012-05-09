using System;

namespace CAP
{
    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message.
    /// </summary>
    public class Info
    {
        private string _language;

        /// <summary>
        /// Gets or sets the code denoting the language of the info sub-element of the alert message.
        /// </summary>
        public string Language
        {
            get { return String.IsNullOrWhiteSpace(_language) ? "en-US" : _language; }
            set { _language = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Category { get; set; }

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
        public string Urgency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Severity? Severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Certainty { get; set; }

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
        public DateTime Effective { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Onset { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Expires { get; set; }

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
}
