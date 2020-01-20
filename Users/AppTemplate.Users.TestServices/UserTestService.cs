using AppTemplate.Users.UserManagement;
using TestsCore;

namespace AppTemplate.Users.TestServices
{
    public interface IUserTestService : ICrudTestService<UserModel>
    {
    }

    public class UserTestService : CrudTestService<UserModel>, IUserTestService
    {
        public UserTestService(WebCore.WebClient.RestClient client) : base(client)
        {
        }

        public override string Url => UsersRoutes.Users;
    }
}
