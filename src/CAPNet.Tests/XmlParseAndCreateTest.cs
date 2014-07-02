using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

using CAPNet.Models;

using Xunit;

namespace CAPNet.Tests
{
    public class XmlParseAndCreateTest
    {
        [Fact]
        public void OrangeAlertXmlGeneralTest()
        {
            string xmlContent = Xml.OrangeAlertXml;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

        [Fact]
        private void MultipleCircleXmlGeneralTest()
        {
            string xmlContent = Xml.MultipleCircleXml;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

        [Fact]
        private void MultipleParameterXmlGeneralTest()
        {
            string xmlContent = Xml.MultipleParameterTestXml;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
        }

        [Fact]
        private void ThunderStorm12AllDatesXmlGeneralTest()
        {
            string xmlContent = Xml.Thunderstorm12AllDatesXml;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

        [Fact]
        private void AllElementsFilledXmlGeneralTest()
        {
            string xmlContent = Xml.AllElementsFilledAlert;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

        [Fact]
        private void SevereThunderStormCap11GeneralTest()
        {
            string xmlContent = Xml.SevereThundertromCap11;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

        [Fact]
        private void HomeLandSecurityAlertCap11GeneralTest()
        {
            string xmlContent = Xml.HomeLandSecurityAlertCap11;
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, xmlContent);
        }

    }
}
