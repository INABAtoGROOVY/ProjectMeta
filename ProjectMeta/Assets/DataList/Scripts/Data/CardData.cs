using System;

[Serializable]
public class CardData
{
    public int Id;
    public string Name;
    public int Cost;
    public int activaterId;
    public int CardAffectId;
    public CardAffectType CardAffectType;

    public CardData(){}

    public CardData(int id)
    {
        Id = id;
    }
}
