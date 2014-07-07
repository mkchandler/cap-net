using System;
using System.Collections.Generic;

namespace CAPNet.Models
{
    /// <summary>
    /// The container for all component parts of the info sub-element of the alert message.
    /// </summary>
    public class Info
    {
        private string language;

        private readonly ICollection<Parameter> parameters;

        private readonly ICollection<EventCode> eventCodes;

        private readonly ICollection<Category> categories;

        private readonly ICollection<Resource> resources;

        private readonly ICollection<Area> areas;

        private readonly ICollection<ResponseType> responseTypes;

        /// <summary>
        /// 
        /// </summary>
        public readonly string DefaultLanguage = "en-US";

        /// <summary>
        /// 
        /// </summary>
        public Info()
        {
            parameters = new List<Parameter>();
            eventCodes = new List<EventCode>();
            categories = new List<Category>();
            resources = new List<Resource>();
            areas = new List<Area>();
            responseTypes = new List<ResponseType>();
        }

        /// <summary>
        /// Gets or sets the code denoting the language of the info sub-element of the alert message.
        /// </summary>
        public string Language
        {
            get { return String.IsNullOrWhiteSpace(language) ? DefaultLanguage : language; }
            set { language = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ResponseType> ResponseTypes
        {
            get
            {
                return responseTypes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Category> Categories
        {
            get { return categories; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Urgency Urgency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Severity Severity { get; set; }

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
        public Uri Web { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// System-specific additional parameters associated
        /// with the alert message (OPTIONAL)
        /// </summary>
        public ICollection<Parameter> Parameters
        {
            get { return parameters; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<EventCode> EventCodes
        {
            get { return eventCodes; }

        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Resource> Resources
        {
            get { return resources; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Area> Areas
        {
            get { return areas; }
        }
    }
}
