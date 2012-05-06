using System;
using System.Collections.Generic;

namespace CAP
{
    /// <summary>
    /// The container for all component parts of the alert message.
    /// </summary>
    public class Alert
    {
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
        public DateTime? Sent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageType? MessageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Scope? Scope { get; set; }

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
    public enum MessageType
    {
        Alert,
        Update,
        Cancel,
        Ack,
        Error
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Scope
    {
        Public,
        Restricted,
        Private
    }
}
