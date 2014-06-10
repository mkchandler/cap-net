using System;
using System.Xml.Linq;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlCreatorTests
    {
        [Fact]
        public void XmlNodeReturnedHasCAP12Namespace()
        {
            var alert = new Alert
                            {
                                Identifier = Guid.NewGuid().ToString(),
                                Sender = "victorg@email.com",
                                Sent = DateTimeOffset.Now,
                                Status = Status.Test,
                                MessageType = MessageType.Alert,
                                Scope = Scope.Private
                            };

            XElement xmlElement = XmlCreator.Create(alert);

            Assert.Equal("urn:oasis:names:tc:emergency:cap:1.2", xmlElement.Name.NamespaceName);
        }

    }
}
