using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AppTemplate.UserManagement.Tests
{
    public class UsersTests : IClassFixture<TestApplicationFactory>
    {
        private readonly TestApplicationFactory factory;

        public UsersTests(TestApplicationFactory factory)
        {
            this.factory = factory;
        }
        
    }
}
