using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Models;

namespace CAPNet
{
    public class AreaDescriptionRequiredValidatorTests
    {
        [Fact]
        public void AreaWithAreaDescriptionIsValid()
        {
            var area = new Area();
            area.Description = "U.S. nationwide and interests worldwide";

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.True(areaDescriptionRequiredValidator.IsValid);
            Assert.Equal(0, areaDescriptionRequiredValidator.Errors.Count());
        }

        [Fact]
        public void AreaWithAreaDescriptionNullIsInvalid()
        {
            var area = new Area();
            area.Description = null;

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.False(areaDescriptionRequiredValidator.IsValid);
            Assert.Equal(1, areaDescriptionRequiredValidator.Errors.Count());
        }

        [Fact]
        public void AreaWithAreaDescriptionEmptyIsInvalid()
        {
            var area = new Area();
            area.Description = string.Empty;

            var areaDescriptionRequiredValidator = new AreaDescriptionRequiredValidator(area);
            Assert.False(areaDescriptionRequiredValidator.IsValid);
            Assert.Equal(1, areaDescriptionRequiredValidator.Errors.Count());
        }
    }
}
