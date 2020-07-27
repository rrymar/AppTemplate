using Core.Tests;
using Users.UserManagement;

namespace Users.TestServices.UserManagement
{
    public interface IUserTestService : ICrudTestService<UserModel>
    {
    }

    public class UserTestService : CrudTestService<UserModel>, IUserTestService
    {
        public UserTestService(Core.Web.WebClient.RestClient client) : base(client)
        {
        }

        public override string Url => UsersRoutes.Users;
    }
}
