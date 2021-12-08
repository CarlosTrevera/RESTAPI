using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UTO.UnitTesting.Sqlite.Tests
{
    public class DbContextTests : TestHelper
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await APIDbInMemoryContext.Database.CanConnectAsync());
        }

    }
}
