using System.Collections.Generic;
using UnityEngine;

public class CardAreaEntityBase : EntityBase
{
    public List<CardEntity> cardEntities = new List<CardEntity>();

    public CardAreaEntityBase(int id) : base(id)
    {
    }
}
