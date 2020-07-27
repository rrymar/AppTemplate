using AppTemplate.Users.Database;
using Core.Web.Errors;
using Core.Database.Extensions;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class UpdateUserHandler
    {
        private readonly UsersDataContext dataContext;

        private readonly UserMapper mapper;

        public UpdateUserHandler(UsersDataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal void Handle(UserModel model)
        {
            var user = dataContext.Users.Find(model.Id);
            if (user == null)
                throw new NotFoundException();

            mapper.ToEntity(model, user);

            var changes = user.Roles.GetChanges(model.Roles, (e, m) => e.RoleId == m.RoleId);

            changes.RemoveDeleted(dataContext.UserRoles);
            changes.CreateAdded(dataContext.UserRoles,
                (m, e) =>
                {
                    e.RoleId = m.RoleId;
                    e.UserId = user.Id;
                });

            dataContext.SaveChanges();
        }
    }
}
