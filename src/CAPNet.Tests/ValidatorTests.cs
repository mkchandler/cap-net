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
    }
}
