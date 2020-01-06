using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AppTemplate.UserManagement.Users
{
    [ApiController]
    [Route(UserManagementRoutes.Users)]
    public class UsersController : ControllerBase
    {
        private readonly SearchUserQueryHandler searchHandler;

        public UsersController(SearchUserQueryHandler searchHandler)
        {
            this.searchHandler = searchHandler;
        }

        [HttpGet]
        public List<UserModel> Get()
        {
            return searchHandler.Handle();
        }
    }
}
