using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTO.restApi.Controllers;
using UTO.restApi.Models;
using UTO.UnitTesting.Sqlite.Data;
using Xunit;

namespace UTO.UnitTesting.Sqlite.Tests
{
    public class UsersTests : TestHelper
    {


        [Fact]
        public async void SaveAsync_User_RightRecord()
        {

            var helper = new UsersController(APIDbInMemoryContext);
            var mockdata = new MockData();   
            var userCommand = mockdata.SeedUsers();
            var createUser = await helper.PostUser(userCommand);

            var result = helper.GetUser().Result;

            Assert.NotNull(result);
        }


        [Fact]
        public async void GetAsync_UserById_RightRecord()
        {

            var helper = new UsersController(APIDbInMemoryContext);
            var mockdata = new MockData();

            var userCommand = mockdata.SeedUsers();
            var createUser = await helper.PostUser(userCommand);

            var userId = userCommand.UserId;
            var result = await helper.GetUser(userId);

            Assert.NotNull(result);
            
        }

        [Fact]
        public async void UpdateAsync_UserById_RightRecord()
        {
            var helper = new UsersController(APIDbInMemoryContext);
            var mockdata = new MockData();

            var userCommand = mockdata.SeedUsers();
            var createUser = await helper.PostUser(userCommand);

            var userId = userCommand.UserId;

            var result = await helper.PutUser(userId, userCommand);
            
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteAsync_UserById_RightRecord()
        {
            var helper = new UsersController(APIDbInMemoryContext);
            var mockdata = new MockData();
            var userCommand = mockdata.SeedUsers();
            var createUser = await helper.PostUser(userCommand);

            var userId = userCommand.UserId;

            var deleteUser = await helper.DeleteUser(userId);

            var result = (await helper.GetUser()).Result;

            Assert.Null(result);

            


        }


    }
}
