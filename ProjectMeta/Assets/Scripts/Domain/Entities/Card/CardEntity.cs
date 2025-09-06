public class CardEntity : EntityBase<CardEntity>
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public CardEntity(
        int id,
        string name,
        string description
    ) : base(id)
    {
        Name = name;
        Description = description;
    }
}