using Core.Database;
using Core.Web.Errors;
using System.Linq;
using Users.Database;

namespace Users.UserManagement.Handlers
{
    public class DeleteUserHandler
    {
        private readonly UsersDataContext dataContext;

        public DeleteUserHandler(UsersDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        internal void Handle(int id)
        {
            System.Threading.Thread.Sleep(2000); // testing loaders

            if (KnownUsers.SystemUsers.Contains(id))
                throw new BusinessValidationException("System users can't be deleted.");

            var user = dataContext.Users.Find(id);
            if (user == null) return;

            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }
    }
}
