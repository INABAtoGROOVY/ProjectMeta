using System;
using UnityEditor;
using UnityEngine;

public class CardDataListUpdateSelectEditorWindow : EditorWindow
{
    private static readonly string MENU_NAME = "Choose menu";

    private CardData cardData;
    private CardIllustData cardIllustData;
    private Action onUpdate;
    private Action onDelete;

    public static void ShowWindow(
        CardData cardData = null,
        CardIllustData cardIllustData = null,
        Action onUpdate = null,
        Action onDelete = null
    )
    {
        var window = GetWindow<CardDataListUpdateSelectEditorWindow>(MENU_NAME);
        if(cardData != null)
        {
            window.cardData = cardData.DeepCopy();
        }
        if (cardIllustData != null)
        {
            window.cardIllustData = new CardIllustData(cardIllustData.Id, cardIllustData.Name, cardIllustData.Image);
        }
        else
        {
            // カードIDと一致したIDを初期値として渡す
            window.cardIllustData = new CardIllustData(cardData.Id, "", null);
        }
        if (onUpdate != null)
        {
            window.onUpdate = onUpdate;
        }
        if (onDelete != null)
        {
            window.onDelete = onDelete;
        }
    }

    private void OnGUI()
    {
        if(GUILayout.Button("CardSO", GUILayout.Height(50), GUILayout.Width(200)))
        {
            CardSOEditorWindow.ShowWindow(cardData, onUpdate);
            Close();
        }
        if(GUILayout.Button("CardIllustSO", GUILayout.Height(50), GUILayout.Width(200)))
        {
            CardIllustSOEditorWindow.ShowWindow(cardIllustData, onUpdate);
            Close();
        }
        var style = new GUIStyle(GUI.skin.button);
        style.normal.textColor = Color.red;
        style.hover.textColor = Color.red;
        if(GUILayout.Button("Delete Card", style,GUILayout.Height(50), GUILayout.Width(200)))
        {
            CommonPopupEditorWindow.Open(
                "カード削除",
                "カードを削除しますか?\nカードに紐づいたデータはすべて削除されます",
                "はい",
                "いいえ",
                () => 
                {
                    onDelete?.Invoke();
                    onUpdate?.Invoke();
                    Close();
                },
                () => {}
            );
        }
    }
}