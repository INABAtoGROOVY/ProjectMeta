using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CardDataListEditorWindow : EditorWindow
{
    private static readonly string MENU_NAME = "CardDataListEditor";

    private static readonly string BASE_PATH = "Assets/DataList/ScriptableObjects/";
    private static readonly string CARD_SO_PATH = $"{BASE_PATH}CardSO/";
    private static readonly string CARD_ILLUST_SO_PATH = $"{BASE_PATH}CardIllustSO/";

    private static List<CardSO> _cardSOList = new List<CardSO>();
    private static List<CardIllustSO> _cardIllustSOList = new List<CardIllustSO>();

    [MenuItem("Window/CardDataEditor/CardDataList")]
    public static void ShowWindow()
    {
        foreach(var item in Directory.GetFiles(CARD_SO_PATH, "*.asset", SearchOption.AllDirectories))
        {
            var cardSO = AssetDatabase.LoadAssetAtPath<CardSO>(item);
            if (cardSO != null)
            {
                _cardSOList.Add(cardSO);
            }
            //Debug.LogError(item);
        }

        foreach(var item in Directory.GetFiles(CARD_ILLUST_SO_PATH, "*.asset", SearchOption.AllDirectories))
        {
            var cardIllustSO = AssetDatabase.LoadAssetAtPath<CardIllustSO>(item);
            if (cardIllustSO != null)
            {
                _cardIllustSOList.Add(cardIllustSO);
            }
            //Debug.LogError(item);
        }

        GetWindow<CardDataListEditorWindow>(MENU_NAME);
    }

    private bool isControlHorizontal = false;
    private int rawCount = 5;
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        for (var i = 0; i < _cardSOList.Count; i++)
        {
            if(!isControlHorizontal && _cardSOList.Count() > rawCount)
            {
                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(false));
                isControlHorizontal = true;
            }

            CreateCardView(_cardSOList[i].Data.Id, _cardSOList[i].Data.IllustId);

            if(i % rawCount == rawCount - 1 && _cardSOList.Count() > rawCount)
            {
                EditorGUILayout.EndVertical();
                isControlHorizontal = false;
            }
        }
        EditorGUILayout.EndHorizontal();
    }

    private void CreateCardView(int id, int cardIllustId)
    {
        CardIllustSO target = _cardIllustSOList.FirstOrDefault(item => item.Data.Id == cardIllustId);
        if(target == null)
        {
            return;
        }

        //TODO 編集遷移ボタン
        EditorGUILayout.BeginVertical();
        var texture = AssetDatabase.LoadAssetAtPath<Texture>(AssetDatabase.GetAssetPath(target.Data.Image));
        GUILayout.Button(texture, GUILayout.Height(16 * 10), GUILayout.Width(9 * 10));
        GUILayout.Label($"ID : {id}", GUILayout.Height(20), GUILayout.Width(9 * 10));
        EditorGUILayout.EndVertical();
    }
}