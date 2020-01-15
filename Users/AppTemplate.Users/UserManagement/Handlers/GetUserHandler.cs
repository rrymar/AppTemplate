using AppTemplate.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Web.Core.Errors;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class GetUserHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        public GetUserHandler(DataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal UserModel Handle(int id)
        {
            var user = dataContext.Users.Where(u => u.Id == id)
                .Include(u => u.Roles).ThenInclude(r => r.Role)
                .SingleOrDefault();

            if (user == null)
                throw new NotFoundException();

            return mapper.ToModel(user);
        }
    }
}
