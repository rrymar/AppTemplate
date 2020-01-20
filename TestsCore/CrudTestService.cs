using WebCore.WebClient;

namespace TestsCore
{
    public abstract class CrudTestService<TModel, TEntity> : ICrudTestService<TModel, TEntity>
    {
        protected readonly RestClient client;

        public abstract string Url { get; }

        public CrudTestService(RestClient client)
        {
            this.client = client;
        }

        public virtual TModel Get(int id)
        {
            var request = new RestRequest(Url + "/" + id);
            return client.Get<TModel>(request);
        }
    }
}
