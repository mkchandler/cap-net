using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredCertaintyTests
    {
        [Fact]
        public void ValidRequiredCertainty()
        {
            var info = InfoCreator.CreateValidInfo();
            var certaintyValidator = new CertaintyRequiredValidator(info);
            Assert.True(certaintyValidator.IsValid);
            Assert.Equal(0, certaintyValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredCertainty()
        {
            var certaintyValidator = new CertaintyRequiredValidator(new Info());
            Assert.False(certaintyValidator.IsValid);
            Assert.Equal(1, certaintyValidator.Errors.Count());
        }
    }
}
