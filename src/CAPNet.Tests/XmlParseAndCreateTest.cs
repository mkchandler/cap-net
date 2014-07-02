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
            string filePath = Xml.OrangeAlertXml;
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, filePath);
        }

        [Fact]
        private void MultipleCircleXmlGeneralTest()
        {
            string filePath = Xml.MultipleCircleXml;
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, filePath);
        }

        [Fact]
        private void MultipleParameterXmlGeneralTest()
        {
            string filePath = Xml.MultipleParameterTestXml;
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            //Assert.Equal(alertElementString, filePath);
        }

        [Fact]
        private void ThunderStorm12AllDatesXmlGeneralTest()
        {
            string filePath = Xml.Thunderstorm12AllDatesXml;
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, filePath);
        }

        [Fact]
        private void AllElementsFilledXmlGeneralTest()
        {
            string filePath = Xml.AllElementsFilledAlert;
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, filePath);
        }



        private string XmlTrim(string xmlContent)
        {
            string result = "";
            string[] xmlArray = xmlContent.Split('>');

            for (int i = 0; i < xmlArray.Count(); i++)
            {
                result += xmlArray[i].Trim();
                result += ">";
            }

            return result.Substring(0, result.Count()-1);
        }




    }
}
