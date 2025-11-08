using UnityEngine;

public class CardFactory
{
    public CardEntity Create(
        int id,
        int cardAffectId,
        int illustrationId,
        string name
    ) => new CardEntity(id, cardAffectId, illustrationId, name);
}
