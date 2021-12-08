using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTO.restApi.Models;

namespace UTO.UnitTesting.Sqlite
{
    public abstract class TestHelper : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection connection;
        protected readonly APIDbContext APIDbInMemoryContext;

        protected TestHelper()
        {
            connection = new SqliteConnection(InMemoryConnectionString);
            connection.Open();
            var builder = new DbContextOptionsBuilder<APIDbContext>()
                    .UseSqlite(connection);

            var dbContextOptions = builder.Options;

            APIDbInMemoryContext = new APIDbContext(dbContextOptions);
            APIDbInMemoryContext.Database.EnsureDeleted();
            APIDbInMemoryContext.Database.EnsureCreated();

        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}