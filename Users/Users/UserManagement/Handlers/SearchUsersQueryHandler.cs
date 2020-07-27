using AppTemplate.Users.Database;
using Core.Web.Crud;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

namespace Users.UserManagement.Handlers
{
    public class SearchUsersQueryHandler
    {
        private readonly UsersDataContext dataContext;

        private readonly UserMapper mapper;

        public SearchUsersQueryHandler(UsersDataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal ResultsList<UserModel> Handle(SearchQuery query)
        {
            if(query.IsDesc)
                Thread.Sleep(2000); // loader testing

            var queryable = dataContext.Users.Where(e => e.IsActive);
            if (!string.IsNullOrWhiteSpace(query.Keyword))
                queryable.Where(e => EF.Functions.Like(e.FullName, query.Keyword + "%"));

            var totalCount = queryable.Count();
            var items = queryable.ApplyPagingAndSorting(query)
                .Select(mapper.ToModel)
                .ToList();
            return new ResultsList<UserModel>(items, totalCount);
        }
    }
}
