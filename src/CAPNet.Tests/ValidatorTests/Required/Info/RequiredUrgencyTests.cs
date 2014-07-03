using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredUrgencyTests
    {
        [Fact]
        public void ValidRequiredUrgency()
        {
            var info = InfoCreator.CreateValidInfo();
            var urgencyValidator = new UrgencyRequiredValidator(info);
            Assert.True(urgencyValidator.IsValid);
            Assert.Equal(0, urgencyValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredUrgency()
        {
            var urgencyValidator = new UrgencyRequiredValidator(new Info());
            Assert.False(urgencyValidator.IsValid);
            Assert.Equal(1, urgencyValidator.Errors.Count());
        }
    }
}
