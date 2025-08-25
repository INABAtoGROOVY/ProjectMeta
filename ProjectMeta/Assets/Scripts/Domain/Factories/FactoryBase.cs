public class FactoryBase<T> where T : new()
{
    public T Create()
    {
        return new T();
    }
}