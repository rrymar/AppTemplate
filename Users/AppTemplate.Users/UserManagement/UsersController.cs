using AppTemplate.Users.UserManagement.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace AppTemplate.Users.UserManagement
{
    [ApiController]
    [Route(UsersRoutes.Users)]
    public class UsersController : ControllerBase
    {
        private readonly GetUserHandler getHandler;
        private readonly UpdateUserHandler updateHandler;
        private readonly CreateUserHandler createHandler;
        private readonly DeleteUserHandler deleteHandler;

        public UsersController(
            CreateUserHandler createHandler,
            UpdateUserHandler updateHandler,
            DeleteUserHandler deleteHandler, 
            GetUserHandler getHandler)
        {
            this.createHandler = createHandler;
            this.updateHandler = updateHandler;
            this.deleteHandler = deleteHandler;
            this.getHandler = getHandler;
        }

        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            return getHandler.Handle(id);
        }

        [HttpPost]
        public UserModel Post(UserModel user)
        {
            return createHandler.Handle(user);
        }

        [HttpPut("{id}")]
        public UserModel Put(int id, UserModel user)
        {
            user.Id = id;
            return updateHandler.Handle(user);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            deleteHandler.Handle(id);
        }
    }
}
