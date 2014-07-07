using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredInfoTests
    {
        [Fact]
        public void SingleValidRequiredInfo()
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();

            ///one info in alert
            alert.Info.Add(info);
            var singleAlertValidator = new AlertValidator(alert);
            var singleErrorsValidation = singleAlertValidator.Errors;
            //the info should be valid
            Assert.True(singleAlertValidator.IsValid);
            Assert.Equal(0, singleErrorsValidation.Count());
        }

        [Fact]
        public void SingleInvalidRequiredInfo()
        {
            var alert = new Alert();

            /// one info in alert
            alert.Info.Add(new Info());
            var alertValidatorSingle = new AlertValidator(alert);
            var validationErrorsSingle = alertValidatorSingle.Errors;
            // 5 errors detected >> missing subelements : Category , Certainty , Event , Severity , Urgency
            Assert.False(alertValidatorSingle.IsValid);
            Assert.Equal(5, validationErrorsSingle.Count());
        }

        [Fact]
        public void DoubleValidRequiredInfo()
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();

            ///two infos in alert
            alert.Info.Add(info);
            alert.Info.Add(info);
            var doubleAlertValidator = new AlertValidator(alert);
            var doubleErrorsValidation = doubleAlertValidator.Errors;
            //the info should be valid
            Assert.True(doubleAlertValidator.IsValid);
            Assert.Equal(0, doubleAlertValidator.Errors.Count());
        }

        [Fact]
        public void DoubleInvalidRequiredInfo()
        {
            var alert = new Alert();
            /// two infos in alert
            alert.Info.Add(new Info());
            alert.Info.Add(new Info());
            var alertValidatorDouble = new AlertValidator(alert);
            var validationErrorsDouble = alertValidatorDouble.Errors;
            // 10 errors detected >> mising sublements x 2
            Assert.False(alertValidatorDouble.IsValid);
            Assert.Equal(10, validationErrorsDouble.Count());
        }
    }
}
