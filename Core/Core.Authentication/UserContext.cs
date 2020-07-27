using Core.Database;

namespace Core.Authentication
{
    public class UserContext : IUserContext, ICurrentUserLocator
    {
        public int UserId => KnownUsers.System;
    }
}
