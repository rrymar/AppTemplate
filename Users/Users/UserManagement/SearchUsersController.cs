using Core.Web.Crud;
using Microsoft.AspNetCore.Mvc;
using Users.UserManagement.Handlers;

namespace Users.UserManagement
{
    [ApiController]
    [Route(UsersRoutes.SearchUsers)]
    public class SearchUsersController : ControllerBase
    {
        private readonly SearchUsersQueryHandler handler;
        
        public SearchUsersController(SearchUsersQueryHandler handler)
        {
            this.handler = handler;
        }

        [HttpPost]
        public ResultsList<UserModel> Post([FromBody] SearchQuery query)
        {
            return handler.Handle(query);
        }
    }
}
