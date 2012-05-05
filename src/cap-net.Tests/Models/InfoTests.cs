using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace CAP.Tests.Models
{
    public class InfoTests
    {
        [Fact]
        public void LanguageDefaultsToEnglish()
        {
            var info = new Info();

            Assert.Equal("en-US", info.Language);
        }
    }
}
