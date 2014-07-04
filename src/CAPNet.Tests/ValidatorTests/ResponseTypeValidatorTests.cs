using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet.Tests.ValidatorTests
{
    public class ResponseTypeOptionalValidatorTests
    {
        [Fact]
        public void ResponseTypeWithValidElementIsValid()
        {
            var responseType = ResponseType.Evacuate;
            var responseTypeOptionalValidator = new ResponseTypeValidator(responseType);
            Assert.True(responseTypeOptionalValidator.IsValid);
        }

        [Fact]
        public void ResponseTypeWithInvalidElementIsinvalid()
        {
            var responseType = (ResponseType)123;
            var responseTypeOptionalValidator = new ResponseTypeValidator(responseType);
            Assert.False(responseTypeOptionalValidator.IsValid);
        }
    }
}
