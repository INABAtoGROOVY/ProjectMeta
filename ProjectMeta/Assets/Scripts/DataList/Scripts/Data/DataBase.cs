using UnityEngine;

public abstract class DataBase
{
    public DataBase CreateCopy()
    {
        var json = JsonUtility.ToJson(this);
        return (DataBase)JsonUtility.FromJson(json, GetType());
    }
}
