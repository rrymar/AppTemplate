using AppTemplate.Users.UserManagement.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Users.UserManagement
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
            createHandler.Handle(user);
            return getHandler.Handle(user.Id);
        }

        [HttpPut("{id}")]
        public UserModel Put(int id, UserModel user)
        {
            user.Id = id;
            updateHandler.Handle(user);
            return getHandler.Handle(user.Id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            deleteHandler.Handle(id);
        }
    }
}
