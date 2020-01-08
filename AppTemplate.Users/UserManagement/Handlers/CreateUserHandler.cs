using AppTemplate.Database;
using AppTemplate.Database.Users;
using System.Linq;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class CreateUserHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        private readonly GetUserHandler getUserHandler;

        public CreateUserHandler(DataContext dataContext, UserMapper mapper, 
            GetUserHandler getUserHandler)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.getUserHandler = getUserHandler;
        }

        internal UserModel Handle(UserModel model)
        {
            var user = mapper.ToEntity(model);
            dataContext.Users.Add(user);

            user.Roles = model.Roles?.Select(e =>
            {
                return new UserRole()
                {
                    RoleId = e.RoleId
                };
            }).ToList();

            dataContext.SaveChanges();

            return getUserHandler.Handle(user.Id);
        }
    }
}
