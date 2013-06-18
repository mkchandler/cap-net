using System;
using System.Collections.Generic;

namespace CAPNet
{
    /// <summary>
    /// The container for all component parts of the alert message.
    /// </summary>
    public class Alert
    {
        /// <summary>
        /// 
        /// </summary>
        public Alert()
        {
            _info = new List<Info>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Sent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Scope Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Restriction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Addresses { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string References { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Incidents { get; set; }

        private ICollection<Info> _info;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Info> Info
        {
            get { return _info; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 
        /// </summary>
        Actual,
        /// <summary>
        /// 
        /// </summary>
        Excercise,
        /// <summary>
        /// 
        /// </summary>
        System,
        /// <summary>
        /// 
        /// </summary>
        Test,
        /// <summary>
        /// 
        /// </summary>
        Draft
    }

    /// <summary>
    /// 
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 
        /// </summary>
        Alert,
        /// <summary>
        /// 
        /// </summary>
        Update,
        /// <summary>
        /// 
        /// </summary>
        Cancel,
        /// <summary>
        /// 
        /// </summary>
        Ack,
        /// <summary>
        /// 
        /// </summary>
        Error
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// 
        /// </summary>
        Public,
        /// <summary>
        /// 
        /// </summary>
        Restricted,
        /// <summary>
        /// 
        /// </summary>
        Private
    }
}
