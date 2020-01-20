using AppTemplate.Database.Users;
using AppTemplate.Users.UserManagement;
using TestsCore;

namespace AppTemplate.Users.TestServices
{
    public class UserTestService : CrudTestService<UserModel, User>
    {
        public UserTestService(WebCore.WebClient.RestClient client) : base(client)
        {
        }

        public override string Url => UsersRoutes.Users;
    }
}
