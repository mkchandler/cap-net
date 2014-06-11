using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CAPNet.Models;

using Xunit;

namespace CAPNet.Tests.Models
{
    public class InfoTests
    {
        [Fact]
        public void LanguageDefaultsToEnglish()
        {
            var info = new Info();

            Assert.Equal("en-US", info.Language);
        }

        [Fact]
        public void LanguageSetsToUserValue()
        {
            var info = new Info();
            info.Language = "en-UK";

            Assert.Equal("en-UK", info.Language);
        }
    }
}
