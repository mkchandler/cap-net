using System;
using System.Linq;

using CAPNet.Models;

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

        [Fact]
        public void InfoHasMetCategory()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);
            Assert.Contains(Category.Met, alert.Info.ElementAt(0).Categories);
        }

        [Fact]
        public void UrgencyIsSet()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);

            Assert.Equal(Urgency.Immediate, alert.Info.ElementAt(0).Urgency);
        }

        [Fact]
        public void CertaintyIsSet()
        {
            var alert = XmlParser.Parse(Examples.Thunderstorm12Xml);

            Assert.Equal(Certainty.Observed, alert.Info.ElementAt(0).Certainty);
        }

        /// <summary>
        /// For backward compatibility with CAP 1.0, the deprecated value of “Very Likely” SHOULD be treated as equivalent to “Likely”.
        /// </summary>
        [Fact]
        public void VeryLikelyIsTreatedAsLikely()
        {
            var alert = XmlParser.Parse(Examples.VeryLikelyOrangeAlertXml);

            Assert.Equal(Certainty.Likely, alert.Info.ElementAt(0).Certainty);
        }
    }
}
