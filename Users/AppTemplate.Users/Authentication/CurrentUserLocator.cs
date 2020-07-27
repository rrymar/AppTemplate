using Core.Database;

namespace AppTemplate.UserManagement.Authentication
{
    public class CurrentUserLocator : ICurrentUserLocator
    {
        public int UserId => KnownUsers.System;
    }
}
