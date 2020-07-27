using Core.Database;

namespace Users.Authentication
{
    public class CurrentUserLocator : ICurrentUserLocator
    {
        public int UserId => KnownUsers.System;
    }
}
