using AppTemplate.Users.UserManagement.Handlers;
using Microsoft.AspNetCore.Mvc;
using WebCore.Crud;

namespace AppTemplate.Users.UserManagement
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
