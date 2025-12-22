using System;
using UnityEditor;
using UnityEngine;

public class CardSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardSO/CardSO_{0}";
    private static string menuName = "Update CardSO";

    private CardData cardData = new CardData();

    private Action onUpdate = null;

    public static void ShowWindow(CardData cardData = null, Action onUpdate = null)
    {
        var window = GetWindow<CardSOEditorWindow>(menuName);
        if(cardData != null)
        {
            window.cardData = cardData.DeepCopy();
        }
        if (onUpdate != null)
        {
            window.onUpdate = onUpdate;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label(menuName, EditorStyles.boldLabel);
        ShowTextFields<CardData>(cardData);
        GUILayout.Space(30);
        if (GUILayout.Button("Update"))
        {
            CommonPopupEditorWindow.Open(
                menuName,
                $"CardSOを更新しますか?\nID : {cardData.Id}",
                "はい",
                "いいえ",
                () =>
                {
                    Create<CardSO>(string.Format(fileName, cardData.Id),(asset) => asset.Data = cardData);
                    onUpdate?.Invoke();
                    Close();
                },
                () =>
                {
                    //Close();
                }
            );
        }
    }
}