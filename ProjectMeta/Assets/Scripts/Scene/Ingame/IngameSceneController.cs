using System.ComponentModel.DataAnnotations;
using UnityEngine;

public class IngameSceneController : MonoBehaviour
{
    [SerializeField]
    private CardFactory cardFactory;

    public void Start()
    {
        カード生成テスト();
    }

    public void カード生成テスト()
    {
        var card = cardFactory.Create(1);
        Debug.Log(card.Name);
    }
}