﻿using Core.Web.Errors;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Users.Database;

namespace Users.UserManagement.Handlers
{
    public class GetUserHandler
    {
        private readonly UsersDataContext dataContext;

        private readonly UserMapper mapper;

        public GetUserHandler(UsersDataContext dataContext, UserMapper mapper)
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
