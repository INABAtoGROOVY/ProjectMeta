public class CardAffectEntity : EntityBase
{
    public CardAffectType CardAffectType { get; protected set; }
    public int Cost { get; protected set; }
    //TODO 
    public CardAffectEntity(
        int id,
        CardAffectType cardAffectType,
        int cost
    ) : base(id)
    {
        CardAffectType = cardAffectType;
        Cost = cost;
    }
}