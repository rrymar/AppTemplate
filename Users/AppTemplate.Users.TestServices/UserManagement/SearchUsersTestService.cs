using AppTemplate.Users.UserManagement;
using WebCore.Crud;
using WebCore.WebClient;

namespace AppTemplate.Users.TestServices.UserManagement
{
    public class SearchUsersTestService
    {
        protected readonly RestClient client;

        public SearchUsersTestService(RestClient client)
        {
            this.client = client;
        }

        public ResultsList<UserModel> Search(SearchQuery query)
        {
            var request = UsersRoutes.SearchUsers.ToRestRequest();
            request.AddJsonContent(query);

            return client.Post<ResultsList<UserModel>>(request);
        }
    }
}
