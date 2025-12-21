
using UnityEditor;
using UnityEngine;

public class CardIllustSOEditorWindow : CreateSOEditorWindow
{
    private string fileName = "CardIllustSO/CardIllustSO_{0}";
    private static string menuName = "Update CardIllustSO";

    private CardIllustData cardIllustData = new CardIllustData();

    [MenuItem("Window/CardDataEditor/CardIllustSO")]
    public static void ShowWindow()
    {
        GetWindow<CardIllustSOEditorWindow>(menuName);
    }

    private void OnGUI()
    {
        GUILayout.Label(menuName, EditorStyles.boldLabel);
        ShowTextFields<CardIllustData>(cardIllustData);
        GUILayout.Space(30);
        if (GUILayout.Button("Update"))
        {
            CommonPopupEditorWindow.Open(
                menuName,
                $"CardIllustSOを更新しますか?\nID : {cardIllustData.Id}",
                "はい",
                "いいえ",
                () => Create<CardIllustSO>(
                    string.Format(fileName, cardIllustData.Id),
                    (asset) => asset.Data = cardIllustData
                )
            );
        }
    }
}