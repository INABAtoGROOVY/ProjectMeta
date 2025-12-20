using UnityEditor;
using UnityEngine;

public class CardSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardSO_{0}";

    private CardData cardData = new CardData();

    [MenuItem("Window/CardDataEditor/CardSO")]
    public static void ShowWindow()
    {
        GetWindow<CardSOEditorWindow>("CardDataEditor(Create)");
    }

    private void OnGUI()
    {
        GUILayout.Label("Card Data Editor (Create)", EditorStyles.boldLabel);
        ShowTextFields<CardData>(cardData);
        GUILayout.Space(30);
        if (GUILayout.Button("Update CardSO"))
        {
            Create<CardSO>(
                cardData.Id,
                string.Format(fileName, cardData.Id),
                (asset) => asset.data = cardData
            );
        }
    }
}