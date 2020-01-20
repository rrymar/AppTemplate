using AppTemplate.Database;
using AppTemplate.Database.Users;
using System.Linq;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class CreateUserHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        public CreateUserHandler(DataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal void Handle(UserModel model)
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
            model.Id = user.Id;
        }
    }
}
