using AppTemplate.Database;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class DeleteUserHandler
    {
        private readonly DataContext dataContext;

        public DeleteUserHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        internal void Handle(int id)
        {
            var user = dataContext.Users.Find(id);
            if (user == null) return;

            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }
    }
}
