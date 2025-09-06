public class CardAffectEntity : EntityBase<CardAffectEntity>
{
    public CardAffectType CardAffectType { get; protected set; }
    public CardAffectEntity(
        int id,
        CardAffectType cardAffectType
    ) : base(id)
    {
        CardAffectType = cardAffectType;
    }
}