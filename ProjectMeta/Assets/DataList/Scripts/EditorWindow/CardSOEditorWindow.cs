using UnityEditor;
using UnityEngine;

public class CardSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardSO/CardSO_{0}";
    private static string menuName = "Update CardSO";

    private CardData cardData = new CardData();

    [MenuItem("Window/CardDataEditor/CardSO")]
    public static void ShowWindow()
    {
        GetWindow<CardSOEditorWindow>(menuName);
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
                () => Create<CardSO>(
                    string.Format(fileName, cardData.Id),
                    (asset) => asset.Data = cardData
                )
            );
        }
    }
}