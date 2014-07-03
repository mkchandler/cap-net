using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredDescriptionTest
    {
        [Fact]
        public void InvalidDescription()
        {
            var alert = ResourceDescriptionCreator(null);

            var descriptionValidator = new DescriptionRequiredValidator(alert);
            Assert.False(descriptionValidator.IsValid);
            Assert.Equal(1, descriptionValidator.Errors.Count());
        }

        [Fact]
        public void ValidDescription()
        {
            var alert = ResourceDescriptionCreator("Description");

            var descriptionValidator = new DescriptionRequiredValidator(alert);
            Assert.True(descriptionValidator.IsValid);
        }

        private static Alert ResourceDescriptionCreator(string description)
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();
            var resource = new Resource();
            resource.Description = description;
            info.Resources.Add(resource);
            alert.Info.Add(info);

            return alert;
        }
    }
}
