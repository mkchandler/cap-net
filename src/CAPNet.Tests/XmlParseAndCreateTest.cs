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
        public void OrangeAlertXmlParseAndCreate()
        {
            string xmlContent = Xml.OrangeAlertXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleCircleXmlParseAndCreate()
        {
            string xmlContent = Xml.MultipleCircleXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleParameterXmlParseAndCreate()
        {
            string xmlContent = Xml.MultipleParameterTestXml;
            string correctedXmlContent = xmlContent.Replace("Very Likely", "Likely");
            XDocument originalDocument = XDocument.Parse(correctedXmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void ThunderStorm12AllDatesXmlParseAndCreate()
        {
            string xmlContent = Xml.Thunderstorm12AllDatesXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void AllElementsFilledXmlParseAndCreate()
        {
            string xmlContent = Xml.AllElementsFilledAlert;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void SevereThunderStormCap11ParseAndCreate()
        {
            string xmlContent = Xml.SevereThundertromCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void HomeLandSecurityAlertCap11ParseAndCreate()
        {
            string xmlContent = Xml.HomeLandSecurityAlertCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void EarthquakeCap11ParseAndCreate()
        {
            string xmlContent = Xml.EarthquakeCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void AmberParseAndCreate()
        {
            string xmlContent = Xml.AmberAlertCap11;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleThunderstorm12ParseAndCreate()
        {
            string xmlContent = Xml.MultipleThunderstorm12Xml;
            string xmlContentToCap12 = xmlContent.Replace(XmlCreator.CAP11Namespace.ToString(), XmlCreator.CAP12Namespace.ToString());
            XDocument originalDocument = XDocument.Parse(xmlContentToCap12);

            IEnumerable<Alert> alerts = XmlParser.Parse(xmlContent);
            IEnumerable<XElement> createdElements = XmlCreator.Create(alerts);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(new XElement(originalDocument.Root.Name.ToString(), createdElements));

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }


    }
}
