using AppTemplate.Database;
using AppTemplate.Users.Database;

namespace AppTemplate.UserManagement.Authentication
{
    public class CurrentUserLocator : ICurrentUserLocator
    {
        public int UserId => KnownUsers.System;
    }
}
