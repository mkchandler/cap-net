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
        public void AlertXmlGeneralTest()
        {
            XmlGeneralTest(Xml.OrangeAlertXml);
        }

        private void XmlGeneralTest(string filePath)
        {
            Alert alert = XmlParser.Parse(filePath).First();
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();
            Assert.Equal(alertElementString, filePath);
        }




    }
}
