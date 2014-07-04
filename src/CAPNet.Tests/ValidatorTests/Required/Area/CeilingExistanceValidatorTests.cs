using CAPNet.Models;
using System.Linq;
using Xunit;

namespace CAPNet
{
    public class CeilingExistanceValidatorTests
    {
        [Fact]
        public void AreaWithCeilingAndWitAltitudeNullIsInvalid()
        {
            var area = new Area();
            area.Ceiling = 123;
            area.Altitude = null;

            var ceilingExistanceValidator = new CeilingExistanceValidator(area);
            Assert.False(ceilingExistanceValidator.IsValid);
        }

        [Fact]
        public void AreaWithCeilingAndWitAltitudeIsValid()
        {
            var area = new Area();
            area.Ceiling = 123;
            area.Altitude = 142;

            var ceilingExistanceValidator = new CeilingExistanceValidator(area);
            Assert.True(ceilingExistanceValidator.IsValid);
        }
    }
}
