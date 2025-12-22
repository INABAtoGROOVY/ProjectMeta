using System;
using System.Collections.Generic;
using UnityEngine;

public class CardSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardSO/CardSO_{0}";
    private static string menuName = "Update CardSO";

    private CardData cardData = new CardData();

    private Action onUpdate = null;
    private List<int> cardIdList = null;
    private bool isRegisterableId = false;

    public static void ShowWindow(
        CardData cardData = null,
        Action onUpdate = null,
        List<int> cardIdList = null,
        bool isRegisterableId = false
    )
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
        if (cardIdList != null)
        {
            window.cardIdList = cardIdList;
        }
        window.isRegisterableId = isRegisterableId;
    }

    private void OnGUI()
    {
        ShowTextFields<CardData>(cardData, isRegisterableId);
        GUILayout.Space(30);
        if (GUILayout.Button("Update"))
        {
            if(cardIdList != null && cardIdList.Contains(cardData.Id))
            {
                CommonPopupEditorWindow.OpenSingleMessage(
                    menuName,
                    $"IDが重複しています\nID : {cardData.Id}",
                    "はい",
                    () =>
                    {
                    }
                );
            }
            else
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
}