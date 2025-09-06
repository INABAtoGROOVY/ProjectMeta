public class EntityBase<T> where T : class
{
    public int Id { get; protected set; }
    public EntityBase(int id)
    {
        Id = id;
    }
}