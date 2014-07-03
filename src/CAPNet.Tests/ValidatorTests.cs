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
        private Info createValidInfo()
        {
            var info = new Info();

            var category = Category.Fire;

            //Category required
            info.Categories.Add(category);
            //Certainty required
            info.Certainty = Certainty.Observed;
            //EventRequired
            info.Event = "ImportantEvent";
            //SeverityRequired
            info.Severity = Severity.Minor;
            //UrgencyRequired
            info.Urgency = Urgency.Future;

            return info;
        }

        [Fact]
        public void ValidCategory()
        {
            var info = createValidInfo();
            var categoryValidator = new InvalidCategoryValidator(info);
            Assert.True(categoryValidator.IsValid);
            Assert.Equal(0, categoryValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredUrgency()
        {
            var info = createValidInfo();
            var urgencyValidator = new UrgencyRequiredValidator(info);
            Assert.True(urgencyValidator.IsValid);
            Assert.Equal(0, urgencyValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredSeverity()
        {
            var info = createValidInfo();
            var severityValidator = new SeverityRequiredValidator(info);
            Assert.True(severityValidator.IsValid);
            Assert.Equal(0, severityValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredEvent()
        {
            var info = createValidInfo();
            var eventValidator = new EventRequiredValidator(info);
            Assert.True(eventValidator.IsValid);
            Assert.Equal(0, eventValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredCertainty()
        {
            var info = createValidInfo();
            var certaintyValidator = new CertaintyRequiredValidator(info);
            Assert.True(certaintyValidator.IsValid);
            Assert.Equal(0, certaintyValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredCategories()
        {
            var info = createValidInfo();
            var categoriesValidator = new CategoryRequiredValidator(info);
            Assert.True(categoriesValidator.IsValid);
            Assert.Equal(0, categoriesValidator.Errors.Count());
        }

        [Fact]
        public void ValidRequiredInfo()
        {
            var alert = new Alert();
            var info = createValidInfo();

            ///one info in alert
            alert.Info.Add(info);
            var alertValidatorSingle = new AlertValidator(alert);
            var validationErrorsSingle = alertValidatorSingle.Errors;
            //the info should be valid
            Assert.True(alertValidatorSingle.IsValid);
            Assert.Equal(0, validationErrorsSingle.Count());
            
            //two identical infos in alert
            alert.Info.Add(info);
            var alertValidatorDouble = new AlertValidator(alert);
            var validationErrorsDouble = alertValidatorDouble.Errors;
            //the info should be a valid
            Assert.True(alertValidatorDouble.IsValid);
            Assert.Equal(0, alertValidatorDouble.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredUrgency()
        {
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.False(urgencyValidator.IsValid);
            Assert.Equal(1,urgencyValidator.Errors.Count());
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

            /// one info in alert
            alert.Info.Add(new Info());
            var alertValidatorSingle = new AlertValidator(alert);
            var validationErrorsSingle = alertValidatorSingle.Errors;
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.False(alertValidatorSingle.IsValid);
            Assert.Equal(5,validationErrorsSingle.Count());
            
            /// two infos in alert
            alert.Info.Add(new Info());
            var alertValidatorDouble = new AlertValidator(alert);
            var validationErrorsDouble = alertValidatorDouble.Errors;
            // 10 errors detected >> mising sublements x 2
            Assert.False(alertValidatorDouble.IsValid);
            Assert.Equal(10, validationErrorsDouble.Count());
        }
    }
}
