using AppTemplate.Database;
using System.Collections.Generic;
using System.Linq;

namespace AppTemplate.Users.UserManagement
{
    public class SearchUserQueryHandler
    {
        private readonly DataContext dataContext;

        public SearchUserQueryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        internal List<UserModel> Handle()
        {
            return dataContext.Users.Where(e => e.IsActive)
                .Select(e => new UserModel()
                {
                    Id = e.Id,
                    Username = e.Username,
                    FullName = e.FullName
                }).ToList();
        }
    }
}
