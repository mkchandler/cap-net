using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class InvalidCategoryValidatorTests
    {
        [Fact]
        public void CategoryWithValidValueFromTheCategoryEnumIsValid()
        {
            var info = InfoCreator.CreateValidInfo();
            var categoryValidator = new InvalidCategoryValidator(info);
            Assert.True(categoryValidator.IsValid);
            Assert.Equal(0, categoryValidator.Errors.Count());
        }

        [Fact]
        public void CategoryWithInvalidValueFromTheCategoryEnumIsInvalid()
        {
            var info = InfoCreator.CreateInvalidCategory();
            var categoryValidator = new InvalidCategoryValidator(info);
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.Errors.Count());
        }
    }
}
