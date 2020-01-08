using AppTemplate.Database;
using System.Collections.Generic;
using System.Linq;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class SearchUsersQueryHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        public SearchUsersQueryHandler(DataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal List<UserModel> Handle()
        {
            return dataContext.Users.Where(e => e.IsActive)
                .Select(mapper.ToModel).ToList();
        }
    }
}
