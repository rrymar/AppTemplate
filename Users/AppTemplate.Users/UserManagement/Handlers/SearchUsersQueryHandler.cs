using AppTemplate.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using WebCore.Crud;

namespace AppTemplate.Users.UserManagement.Handlers
{
    public class SearchUsersQueryHandler
    {
        private readonly DataContext dataContext;

        private readonly UserMapper mapper;

        public SearchUsersQueryHandler(DataContext dataContext, UserMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        internal ResultsList<UserModel> Handle(SearchQuery query)
        {
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
