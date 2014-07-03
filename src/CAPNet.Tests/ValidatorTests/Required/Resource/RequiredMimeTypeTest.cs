using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using CAPNet.Tests;
using CAPNet.Models;

namespace CAPNet
{
    public class RequiredMimeTypeTest
    {
        [Fact]
        public void InvalidMimeType()
        {
            var alert = ResourceMimeTypeCreator(null);

            var mimeTypeValidator = new MimeTypeRequiredValidator(alert);
            Assert.False(mimeTypeValidator.IsValid);
            Assert.Equal(1, mimeTypeValidator.Errors.Count());
        }

        [Fact]
        public void ValidMimeType()
        {
            var alert = ResourceMimeTypeCreator("MimeTypeResource");

            var mimeTypeValidator = new MimeTypeRequiredValidator(alert);
            Assert.True(mimeTypeValidator.IsValid);
            Assert.Equal(0, mimeTypeValidator.Errors.Count());
        }

        private static Alert ResourceMimeTypeCreator(string mimeType)
        {
            var alert = new Alert();
            var info = InfoCreator.CreateValidInfo();
            var resource = new Resource();
            resource.MimeType = mimeType;
            info.Resources.Add(resource);
            alert.Info.Add(info);
            return alert;
        }
    }
}
