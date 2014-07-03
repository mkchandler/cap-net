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
        public void InvalidCategory()
        {
            var categoryValidator = new InvalidCategoryValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredUrgency()
        {
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.Equal(1,urgencyValidator.Errors.Count());
            Assert.False(urgencyValidator.IsValid);
        }

        [Fact]
        public void InvalidRequiredSeverity()
        {
            var severityValidator = new SeverityRequiredValidator(new Info());

            Assert.False(severityValidator.IsValid);
            Assert.Equal(1,severityValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredEvent()
        {
            var eventValidator = new EventRequiredValidator(new Info());
            Assert.False(eventValidator.IsValid);
            Assert.Equal(1, eventValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredCertainty()
        {
            var certaintyValidator = new CertaintyRequiredValidator(new Info());
            Assert.False(certaintyValidator.IsValid);
            Assert.Equal(1, certaintyValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredCategories()
        {
            var categoryValidator = new CategoryRequiredValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredInfo()
        {
            var alert = new Alert();
            alert.Info.Add(new Info());
            var alertValidator = new AlertValidator(alert);
            var validationErrors = alertValidator.Errors;
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.Equal(5,validationErrors.Count());
            Assert.False(alertValidator.IsValid);
        }
    }
}
