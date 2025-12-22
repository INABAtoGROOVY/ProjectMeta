using System;
using UnityEditor;
using UnityEngine;

public class CardDataListUpdateSelectEditorWindow : EditorWindow
{
    private static readonly string MENU_NAME = "Choose menu";

    private CardData cardData;
    private CardIllustData cardIllustData;
    private Action onUpdate;

    public static void ShowWindow(CardData cardData = null, CardIllustData cardIllustData = null, Action onUpdate = null)
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
    }
}