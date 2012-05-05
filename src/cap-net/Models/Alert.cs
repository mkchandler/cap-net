using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP
{
    public class Alert
    {
        public string Identifier { get; set; }
        public string Sender { get; set; }
        public DateTime? Sent { get; set; }
        public string Status { get; set; }
        public MessageType? MessageType { get; set; }
        public string Source { get; set; }
        public Scope? Scope { get; set; }
        public string Restriction { get; set; }
        public string Addresses { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string References { get; set; }
        public string Incidents { get; set; }
        public IEnumerable<Info> Infos { get; set; }
    }

    public enum MessageType
    {
        Alert,
        Update,
        Cancel,
        Ack,
        Error
    }

    public enum Scope
    {
        Public,
        Restricted,
        Private
    }
}
