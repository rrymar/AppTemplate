using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Authentication
{
    public interface IUserContext
    {
        int UserId { get; }
    }
}
