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

        public string Category
        {
            get;
            set;
        }

        public string Event
        {
            get;
            set;
        }

        public string ResponseType
        {
            get;
            set;
        }

        public string Urgency
        {
            get;
            set;
        }

        public Severity? Severity
        {
            get;
            set;
        }

        public string Certainty
        {
            get;
            set;
        }

        public string Audience
        {
            get;
            set;
        }

        public string EventCode
        {
            get;
            set;
        }

        public DateTime Effective
        {
            get;
            set;
        }

        public DateTime Onset
        {
            get;
            set;
        }

        public DateTime Expires
        {
            get;
            set;
        }

        public string SenderName
        {
            get;
            set;
        }

        public string Headline
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Instruction
        {
            get;
            set;
        }

        public string Web
        {
            get;
            set;
        }

        public string Contact
        {
            get;
            set;
        }
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
