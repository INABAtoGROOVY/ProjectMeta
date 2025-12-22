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

    //TODO データが増えた時にチェック
    private static List<CardSO> _cardSOList = new List<CardSO>();
    private static List<CardIllustSO> _cardIllustSOList = new List<CardIllustSO>();
    private static int GetUnregisteredCardId() => _cardSOList.Max(item => item.Data.Id) + 1; // 簡易的にインクリメント

    private static readonly int rawCount = 10;
    private static readonly int colomnCount = 3;
    private int currentPage = 0;
    private static int maxPage = 1;

    private bool IsEnablePaging()
    {
        return maxPage > 1;
    }

    private void ChangePage(int diff)
    {
        var nextPage = currentPage + diff;
        if (nextPage < 0) nextPage = maxPage - 1;
        if (nextPage > maxPage - 1) nextPage = 0;
        currentPage = nextPage;
    }

    private static void InitializeData()
    {
        _cardSOList.Clear();
        _cardIllustSOList.Clear();
        foreach(var item in Directory.GetFiles(CARD_SO_PATH, "*.asset", SearchOption.AllDirectories))
        {
            var cardSO = AssetDatabase.LoadAssetAtPath<CardSO>(item);
            if (cardSO != null)
            {
                _cardSOList.Add(cardSO);
            }
        }

        foreach(var item in Directory.GetFiles(CARD_ILLUST_SO_PATH, "*.asset", SearchOption.AllDirectories))
        {
            var cardIllustSO = AssetDatabase.LoadAssetAtPath<CardIllustSO>(item);
            if (cardIllustSO != null)
            {
                _cardIllustSOList.Add(cardIllustSO);
            }
        }
    }

    [MenuItem("Window/CardDataEditor/CardDataList")]
    public static void ShowWindow()
    {
        InitializeData();
        maxPage = Mathf.CeilToInt(_cardSOList.Count/(float)(rawCount*colomnCount));

        GetWindow<CardDataListEditorWindow>(MENU_NAME);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField(MENU_NAME, EditorStyles.boldLabel);
        GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField("新規作成", EditorStyles.boldLabel);
        using (new EditorGUILayout.HorizontalScope())
        {
            if(GUILayout.Button("Card", GUILayout.Height(100), GUILayout.Width(100)))
            {
                CardSOEditorWindow.ShowWindow(new CardData(GetUnregisteredCardId()), () => InitializeData());
            }
            // カードを作成して、一覧から追加設定する想定なので必要なさそう(一応残す)
            // if(GUILayout.Button("CardIllust", GUILayout.Height(100), GUILayout.Width(100)))
            // {
            //     CardIllustSOEditorWindow.ShowWindow(onUpdate: () => InitializeData());
            // }
        }
        GUILayout.Box("", GUILayout.Height(2), GUILayout.ExpandWidth(true));

        EditorGUILayout.LabelField("カード一覧(更新)", EditorStyles.boldLabel);
        if(IsEnablePaging())
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                if(GUILayout.Button("前のページ", GUILayout.Height(60), GUILayout.Width(60)))
                {
                    ChangePage(-1);
                }
                if(GUILayout.Button("次のページ", GUILayout.Height(60), GUILayout.Width(60)))
                {
                    ChangePage(1);
                }
            }
        }

        for (var i = currentPage * rawCount * colomnCount; i < _cardSOList.Count; i += rawCount)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                for (var j = i; j < rawCount + i && j < _cardSOList.Count; j++)
                {
                    CreateCardView(_cardSOList[j].Data);
                }
                GUILayout.FlexibleSpace();
            }
        }
    }

    private void CreateCardView(CardData cardData)
    {
        CardIllustSO target = _cardIllustSOList.FirstOrDefault(item => item.Data.Id == cardData.Id);
        using (new EditorGUILayout.VerticalScope())
        {
            var texture = target == null ? null : AssetDatabase.LoadAssetAtPath<Texture>(AssetDatabase.GetAssetPath(target.Data.Image));
            GUILayout.Label($"ID : {cardData.Id}", GUILayout.Height(20), GUILayout.Width(9 * 10));
            if(GUILayout.Button(texture, GUILayout.Height(16 * 10), GUILayout.Width(9 * 10)))
            {
                CardDataListUpdateSelectEditorWindow.ShowWindow(cardData, target?.Data, () => InitializeData());
            }
        }
    }

    void OnDestroy()
    {
        _cardSOList.Clear();
        _cardIllustSOList.Clear();
    }
}