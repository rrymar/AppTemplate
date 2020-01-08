﻿
namespace WebCore.Contracts
{
    public interface IMapper<TEntity, TModel>
        where TEntity : class
    {
        TEntity ToEntity(TModel model, TEntity entity = null);
        TModel ToModel(TEntity entity);
    }
}