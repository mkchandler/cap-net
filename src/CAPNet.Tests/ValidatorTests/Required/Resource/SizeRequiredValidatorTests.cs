using System.Linq;

using Xunit;
using CAPNet.Models;

namespace CAPNet
{
    public class SizeRequiredValidatorTests
    {
        [Fact]
        public void ResourceWithUriThatHasSizeIsValid()
        {
            var resource = new Resource();
            resource.Uri = new System.Uri("http://www.google.ro");
            resource.Size = 13;

            var sizeRequiredValidator = new SizeRequiredWhenUriValidator(resource);
            Assert.True(sizeRequiredValidator.IsValid);
        }

        [Fact]
        public void ResourceWithUriThatHasSizeNullIsInvalid()
        {
            var resource = new Resource();
            resource.Uri = new System.Uri("https://www.google.ro");
            resource.Size = null;

            var sizeRequiredValidator = new SizeRequiredWhenUriValidator(resource);
            Assert.False(sizeRequiredValidator.IsValid);
        }

        [Fact]
        public void ResourceWithNoUriIsValid()
        {
            var resource = new Resource();

            var sizeRequiredValidator = new SizeRequiredWhenUriValidator(resource);
            Assert.True(sizeRequiredValidator.IsValid);
        }
    }
}
