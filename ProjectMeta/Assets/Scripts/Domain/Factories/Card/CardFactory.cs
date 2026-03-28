using System.Linq;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public CardEntity Create(
        int id
    )
    {
        var so = Resources.Load<CardSO>($"DataList/ScriptableObjects/CardSO/CardSO_{id}");
        if (so == null)
        {
            return null;
        }
        var data = so.Data;

        return new CardEntity(
            id,
            data.CardAffectId,
            data.Name
        );
    }
}