using System;
using System.Xml.Linq;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlCreatorTests
    {
        private const string Sender = "victorg@email.com";

        private static readonly DateTimeOffset Sent = new DateTimeOffset(2014, 6, 10, 10, 35, 23, 512, TimeSpan.FromHours(-3));

        private static readonly Alert Alert = new Alert
                                                  {
                                                      Identifier = Guid.NewGuid().ToString(),
                                                      Sender = Sender,
                                                      Sent = Sent,
                                                      Status = Status.Test,
                                                      MessageType = MessageType.Alert,
                                                      Scope = Scope.Private
                                                  };

        [Fact]
        public void XmlNodeReturnedHasCAP12Namespace()
        {
            XElement xmlElement = XmlCreator.Create(Alert);

            Assert.Equal("urn:oasis:names:tc:emergency:cap:1.2", xmlElement.Name.NamespaceName);
        }

        [Fact]
        public void XmlNodeReturnedHasSender()
        {
            var alertElement = XmlCreator.Create(Alert);

            var senderElement = alertElement.Element(XmlCreator.CAP12Namespace + "sender");

            Assert.NotNull(senderElement);
            Assert.Equal(Sender, senderElement.Value);
        }

        [Fact]
        public void XmlNodeReturnedHasStatus()
        {
            var alertElement = XmlCreator.Create(Alert);

            var statusElement = alertElement.Element(XmlCreator.CAP12Namespace + "status");

            Assert.NotNull(statusElement);
            Assert.Equal("Test", statusElement.Value);
        }

        [Fact]
        public void XmlNodeReturnedHasSentTime()
        {
            var alertElement = XmlCreator.Create(Alert);

            var sentElement = alertElement.Element(XmlCreator.CAP12Namespace + "sent");

            Assert.NotNull(sentElement);
            Assert.Equal("2014-06-10T10:35:23-03:00", sentElement.Value);
        }
    }
}
