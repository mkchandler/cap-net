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
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.Equal(1,urgencyValidator.ValidationError.Count());
            Assert.False(urgencyValidator.IsValid);
        }

        [Fact]
        public void ValidSeverity()
        {
            var severityValidator = new SeverityRequiredValidator(new Info());

            Assert.False(severityValidator.IsValid);
            Assert.Equal(1,severityValidator.ValidationError.Count());
        }

        [Fact]
        public void ValidEvent()
        {
            var eventValidator = new EventRequiredValidator(new Info());
            Assert.False(eventValidator.IsValid);
            Assert.Equal(1, eventValidator.ValidationError.Count());
        }

        [Fact]
        public void ValidCertainty()
        {
            var certaintyValidator = new CertaintyRequiredValidator(new Info());
            Assert.False(certaintyValidator.IsValid);
            Assert.Equal(1, certaintyValidator.ValidationError.Count());
        }

        [Fact]
        public void ValidCategories()
        {
            var categoryValidator = new CategoryRequiredValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.ValidationError.Count());
        }

        [Fact]
        public void InvalidInfo()
        {
            var alert = new Alert(new Info());
            var alertValidator = new AlertValidator(alert);
            var validationErrors = alertValidator.ValidationErrors();
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.Equal(5,validationErrors.Count());
            Assert.False(alertValidator.IsValid);
        }

        [Fact]
        public void ValidInfo()
        {
            var alert = new Alert(XmlParser.Parse(Xml.MultipleAlertXml).First().Info.ElementAt(0));
            var alertValidator = new AlertValidator(alert);
            var validationErrors = alertValidator.ValidationErrors();
            // 0 errors detected >> no subelement missing 
            Assert.Equal(0, validationErrors.Count());
            Assert.True(alertValidator.IsValid);
        }
    }
}
