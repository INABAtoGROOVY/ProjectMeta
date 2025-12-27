
using System;
using UnityEditor;
using UnityEngine;

public class CardIllustSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardIllustSO/CardIllustSO_{0}";
    private static string menuName = "Update CardIllustSO";

    private CardIllustData cardIllustData = new CardIllustData();

    private Action onUpdate = null;

    public static void ShowWindow(CardIllustData cardIllustData = null, Action onUpdate = null)
    {
        var window = GetWindow<CardIllustSOEditorWindow>(menuName);
        if (cardIllustData != null)
        {
            window.cardIllustData = new CardIllustData(cardIllustData.Id, cardIllustData.Name, cardIllustData.Image);
        }
        if (onUpdate != null)
        {
            window.onUpdate = onUpdate;
        }
    }

    private void OnGUI()
    {
        ShowTextFields<CardIllustData>(cardIllustData);
        GUILayout.Space(30);
        if (GUILayout.Button("Update"))
        {
            CommonPopupEditorWindow.Open(
                menuName,
                $"CardIllustSOを更新しますか?\nID : {cardIllustData.Id}",
                "はい",
                "いいえ",
                () => 
                {
                    Create<CardIllustSO>(string.Format(fileName, cardIllustData.Id),(asset) => asset.Data = cardIllustData);
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