public class CardEntity : EntityBase
{
    //TODO affectを発動してqueueする、queueを取り出して実行する
    public int CardAffectId { get; protected set; }
    public string Name { get; protected set; }

    public CardEntity(
        int id,
        int cardAffectId,
        string name
    ) : base(id)
    {
        CardAffectId = cardAffectId;
        Name = name;
    }

    public string GetDescripton()
    {
        //TODO cardAffectから生成
        return "";
    }

    public string GetCost()
    {
        //TODO cardAffectから生成
        return "";
    }
}