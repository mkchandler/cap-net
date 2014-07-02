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
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void MultipleCircleXmlGeneralTest()
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
        private void MultipleParameterXmlGeneralTest()
        {
            string xmlContent = Xml.MultipleParameterTestXml;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            //Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void ThunderStorm12AllDatesXmlGeneralTest()
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
        private void AllElementsFilledXmlGeneralTest()
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
        private void SevereThunderStormCap11GeneralTest()
        {
            string xmlContent = Xml.SevereThundertromCap11;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void HomeLandSecurityAlertCap11GeneralTest()
        {
            string xmlContent = Xml.HomeLandSecurityAlertCap11;
            XDocument originalDocument = XDocument.Parse(xmlContent);

            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);

            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

        [Fact]
        private void EarthquakeCap11GeneralTest()
        {
            string xmlContent = Xml.EarthquakeCap11;
            XDocument originalDocument = XDocument.Parse(xmlContent);
            
            Alert alert = XmlParser.Parse(xmlContent).First();
            XElement createdElement = XmlCreator.Create(alert);

            XDocument createdDocument = new XDocument();
            createdDocument.Add(createdElement);
            
            Assert.Equal(createdDocument.ToString(), originalDocument.ToString());
        }

    }
}
