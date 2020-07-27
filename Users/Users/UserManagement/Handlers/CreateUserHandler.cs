using AppTemplate.Users.Database;
using Core.Database;
using System.Linq;

namespace Users.UserManagement.Handlers
{
    public class CreateUserHandler
    {
        private readonly UsersDataContext dataContext;

        private readonly UserMapper mapper;

        public CreateUserHandler(UsersDataContext dataContext, UserMapper mapper)
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
