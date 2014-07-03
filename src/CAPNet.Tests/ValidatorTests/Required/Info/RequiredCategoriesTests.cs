using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredCategoriesTests
    {
        [Fact]
        public void ValidRequiredCategories()
        {
            var info = InfoCreator.CreateValidInfo();
            var categoriesValidator = new CategoryRequiredValidator(info);
            Assert.True(categoriesValidator.IsValid);
            Assert.Equal(0, categoriesValidator.Errors.Count());
        }

        [Fact]
        public void InvalidRequiredCategories()
        {
            var categoryValidator = new CategoryRequiredValidator(new Info());
            Assert.False(categoryValidator.IsValid);
            Assert.Equal(1, categoryValidator.Errors.Count());
        }
    }
}
