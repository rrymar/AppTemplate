using AppTemplate.Database;
using AppTemplate.Database.Users;

namespace AppTemplate.UserManagement.Authentication
{
    public class CurrentUserLocator : ICurrentUserLocator
    {
        public int UserId => KnownUsers.System;
    }
}
