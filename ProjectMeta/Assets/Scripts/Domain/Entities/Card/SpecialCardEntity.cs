using UnityEngine;

public class SpecialCardEntity : CardEntity
{
    public SpecialCardEntity(
        int id,
        int cardAffectId,
        int illustrationId,
        string name
    ) : base(id, cardAffectId, illustrationId, name)
    {
    }
}