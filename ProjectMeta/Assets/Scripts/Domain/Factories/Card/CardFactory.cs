public class CardFactory : FactoryBase<CardEntity, CardSO, CardData>
{
    protected override CardEntity CreateImpl(CardData data)
    {
        return new CardEntity(data.Id, data.CardAffectId, data.Name);
    }

    protected override string GetAssetPath(int id)
    {
        return $"DataList/ScriptableObjects/CardSO/CardSO_{id}";
    }
}