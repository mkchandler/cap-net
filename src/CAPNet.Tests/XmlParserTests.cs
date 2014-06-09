using System;
using System.Linq;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlParserTests
    {
        [Fact]
        public void CanReadCAP12Example()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);
            Assert.NotNull(alert.Info.ElementAt(0).Areas.ElementAt(0).Polygon);
        }

        [Fact]
        public void SentTimeHasTimeZone()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);

            Assert.Equal(TimeSpan.FromHours(-7), alert.Sent.Offset);
        }

        [Fact]
        public void DatesInInfoHaveTimeZones()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12AllDatesXml);

            var info = alert.Info.ElementAt(0);

            Assert.Equal(TimeSpan.FromHours(-7), info.Effective.Offset);
            Assert.Equal(TimeSpan.FromHours(-7), info.Onset.Offset);
            Assert.Equal(TimeSpan.FromHours(-7), info.Expires.Offset);
        }

        [Fact]
        public void CanReadAlertStatus()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);
            Assert.Equal(Status.Actual, alert.Status);
        }

        [Fact]
        public void CanReadAlertMessageType()
        {
            var alert = XmlParser.Parse(Examples.ThunderstormUpdate12Xml);
            Assert.Equal(MessageType.Update, alert.MessageType);
        }

        [Fact]
        public void CanReadAlertScope()
        {
            var alert = XmlParser.Parse(Examples.ThunderstormUpdate12Xml);
            Assert.Equal(Scope.Restricted, alert.Scope);
            Assert.Contains("glasses", alert.Restriction);
        }
    }
}
