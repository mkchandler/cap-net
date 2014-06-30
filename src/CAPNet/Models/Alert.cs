using System;
using System.Collections.Generic;

namespace CAPNet.Models
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
            info = new List<Info>();
        }

        /// <summary>
        /// The identifier of the alert message 
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         A number or string uniquely identifying this message, assigned by the sender.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Identifier { get; set; }

        /// <summary>
        /// The identifier of the sender of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         Identifies the originator of this alert. Guaranteed by assigner to be unique globally; e.g., may be based on an Internet domain name.
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         MUST NOT include spaces, commas or restricted characters (&lt; and &amp;).
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public string Sender { get; set; }

        /// <summary>
        /// The time and date of the origination of the alert message.
        /// </summary>
        /// <remarks>
        ///   <list type="number">
        ///     <item>
        ///       <description>
        ///         The date and time SHALL be represented in the DateTime Data Type (See Implementation Notes) format (e.g., "2002-05-24T16:49:00-07:00" for 24 May 2002 at 16:49 PDT).
        ///       </description>
        ///     </item>
        ///     <item>
        ///       <description>
        ///         Alphabetic timezone designators such as "Z" MUST NOT be used. The timezone for UTC MUST be represented as "-00:00".
        ///       </description>
        ///     </item>
        ///     </list>
        /// </remarks>
        public DateTimeOffset Sent { get; set; }

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

        private readonly ICollection<Info> info;

        /// <summary>
        /// 
        /// </summary>
        public ICollection<Info> Info
        {
            get { return info; }
        }
    }
}
