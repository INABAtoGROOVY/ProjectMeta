using System.Linq;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    public CardEntity Create(
        int id
    )
    {
        // var cardData = CardSO.DataList.FirstOrDefault(item => item.Id == id);
        // if (cardData == null)
        // {
        //     return null;
        // }

        // return new CardEntity(
        //     id,
        //     cardData.CardAffectId,
        //     cardData.IllustId,
        //     cardData.Name
        // );
        return null;
    }
}