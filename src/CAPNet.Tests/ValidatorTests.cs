using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class ValidatorTests
    {
        [Fact]
        public void ValidUrgency()
        {
            var alert = new Alert();
            alert.Info.Add(XmlParser.Parse(Xml.MultipleAlertXml).First().Info.ElementAt(0));
            var urgencyValidator = new UrgencyRequiredValidator(alert.Info.ElementAt(0));
            Assert.Equal(0, urgencyValidator.ValidationError.Count());
            Assert.True(urgencyValidator.IsValid);
        }

        [Fact]
        public void ValidSeverity()
        {
            var alert = new Alert();
            alert.Info.Add(XmlParser.Parse(Xml.MultipleAlertXml).First().Info.ElementAt(0));
            var severityValidator = new SeverityRequiredValidator(alert.Info.ElementAt(0));
            Assert.True(severityValidator.IsValid);
            Assert.Equal(0, severityValidator.ValidationError.Count());
        }
        
        [Fact]
        public void ValidInfo()
        {
            var alert = new Alert();
            alert.Info.Add(XmlParser.Parse(Xml.MultipleAlertXml).First().Info.ElementAt(0));
            var alertValidator = new AlertValidator(alert);
            var validationErrors = alertValidator.ValidationErrors();
            // 0 errors detected >> no subelement missing 
            Assert.Equal(0, validationErrors.Count());
            Assert.True(alertValidator.IsValid);
        }

        [Fact]
        public void InvalidUrgency()
        {
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.Equal(1,urgencyValidator.ValidationError.Count());
            Assert.False(urgencyValidator.IsValid);
        }

        [Fact]
        public void InvalidSeverity()
        {
            var severityValidator = new SeverityRequiredValidator(new Info());

            Assert.False(severityValidator.IsValid);
            Assert.Equal(1,severityValidator.ValidationError.Count());
        }

        [Fact]
        public void InvalidEvent()
        {
            var eventValidator = new EventRequiredValidator(new Info());
            Assert.False(eventValidator.IsValid);
            Assert.Equal(1, eventValidator.ValidationError.Count());
        }

        [Fact]
        public void InvalidCertainty()
        {
            var certaintyValidator = new CertaintyRequiredValidator(new Info());
            Assert.False(certaintyValidator.IsValid);
            Assert.Equal(1, certaintyValidator.ValidationError.Count());
        }

        [Fact]
        public void InvalidCategories()
        {
            var categoryValidator = new CategoryRequiredValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.ValidationError.Count());
        }

        [Fact]
        public void InvalidInfo()
        {
            var alert = new Alert();
            alert.Info.Add(new Info());
            var alertValidator = new AlertValidator(alert);
            var validationErrors = alertValidator.ValidationErrors();
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.Equal(5,validationErrors.Count());
            Assert.False(alertValidator.IsValid);
        }
    }
}
