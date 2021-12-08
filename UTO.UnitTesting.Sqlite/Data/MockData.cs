using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTO.restApi.Models;

namespace UTO.UnitTesting.Sqlite.Data
{
    public class MockData
    {
        public User SeedUsers()
        {
            return new User()
            {
                UserName = "Taylor",
                LastName = "Smith",
                EmailUser = "t.smith@mail.com",
                PassUser = "tsp@ssw0rd",
                PhoneUser = "0151457891",
                Status = true
            };
        }

    }
}
