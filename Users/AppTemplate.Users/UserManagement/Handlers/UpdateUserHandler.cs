﻿using AppTemplate.Database;
using Web.Core.Errors;
using AppTemplate.Database.Extensions;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class UpdateUserHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        private readonly GetUserHandler getUserHandler;

        public UpdateUserHandler(DataContext dataContext, UserMapper mapper,
            GetUserHandler getUserHandler)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
            this.getUserHandler = getUserHandler;
        }

        internal UserModel Handle(UserModel model)
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

            return getUserHandler.Handle(user.Id);
        }
    }
}