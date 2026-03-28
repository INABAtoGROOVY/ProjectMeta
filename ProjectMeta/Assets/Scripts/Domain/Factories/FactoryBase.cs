using UnityEngine;

public abstract class FactoryBase<TEntity, TSO, TData>
    where TEntity : EntityBase 
    where TSO : SOBase<TData>
    where TData : DataBase
{
    public TEntity Create(int id)
    {
        var so = Resources.Load<TSO>($"{GetAssetPath(id)}");
        if (so == null)
        {
            return null;
        }
        var data = so.Data;

        return CreateImpl(data);
    }

    protected abstract string GetAssetPath(int id);
    protected abstract TEntity CreateImpl(TData data);
}