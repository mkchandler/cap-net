using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredResourceTest
    {
        [Fact]
        public void ValidResource()
        {
            var alert = ResourceCreator("Description","MimeType");

            var resourceValidator = new ResourceValidator(alert);
            Assert.True(resourceValidator.IsValid);
            Assert.Equal(0, resourceValidator.Errors.Count());
        }

        [Fact]
        public void SemiInvalidResource()
        {
            var alert = ResourceCreator("Description", null);

            var resourceValidator = new ResourceValidator(alert);
            Assert.False(resourceValidator.IsValid);
            Assert.Equal(1, resourceValidator.Errors.Count());
        }

        [Fact]
        public void CompleteInvalidResource()
        {
            var alert = ResourceCreator(null, null);

            var resourceValidator = new ResourceValidator(alert);
            Assert.False(resourceValidator.IsValid);
            Assert.Equal(2, resourceValidator.Errors.Count());
        }

        private static Alert ResourceCreator(string description,string mimeType)
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();
            var resource = new Resource();
            resource.Description = description;
            resource.MimeType = mimeType;
            info.Resources.Add(resource);
            alert.Info.Add(info);

            return alert;
        }
    }
}
