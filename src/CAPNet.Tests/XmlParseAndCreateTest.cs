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
        public void XmlTest()
        {
            Alert alert = XmlParser.Parse(Xml.OrangeAlertXml).First();
            
            XElement alertElement = XmlCreator.Create(alert);
            string alertElementString = alertElement.ToString();

            Assert.Equal(alertElementString, Xml.OrangeAlertXml);
        }

    }
}
