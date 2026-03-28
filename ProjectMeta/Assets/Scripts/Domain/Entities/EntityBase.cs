public abstract class EntityBase
{
    public int Id { get; }

    protected EntityBase(int id)
    {
        Id = id;
    }
}