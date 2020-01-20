using AppTemplate.Database.Users;
using AppTemplate.Users.UserManagement;
using TestsCore;

namespace AppTemplate.Users.TestServices
{
    public interface IUserTestService : ICrudTestService<UserModel, User>
    {
    }

    public class UserTestService : CrudTestService<UserModel, User>, IUserTestService
    {
        public UserTestService(WebCore.WebClient.RestClient client) : base(client)
        {
        }

        public override string Url => UsersRoutes.Users;
    }
}
