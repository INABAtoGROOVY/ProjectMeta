using UnityEngine;

public abstract class SOBase<TData> : ScriptableObject where TData : DataBase
{
    public TData Data;
}