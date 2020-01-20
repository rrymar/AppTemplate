namespace TestsCore
{
    public interface ICrudTestService<TModel, TEntity>
    {
        string Url { get; }

        TModel Get(int id);
    }
}