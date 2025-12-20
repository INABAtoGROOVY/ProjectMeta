using System;
using UnityEditor;
using UnityEngine;

public abstract class CreateSOEditorWindow : EditorWindow
{
    private readonly string BASE_PATH = "Assets/DataList/ScriptableObjects/CardSO/{0}.asset";
    private string GetAssetPath(string fileName, int id) => string.Format(BASE_PATH, fileName);

    protected void Create<T>(
        int id,
        string fileName,
        Action<T> onCreate = null
    ) where T : ScriptableObject
    {
        var asset = CreateInstance<T>();
        onCreate?.Invoke(asset);
        AssetDatabase.CreateAsset(asset,GetAssetPath(fileName, id));
        AssetDatabase.Refresh();
    }

    protected void ShowTextFields<T>(object obj)
    {
        GUILayout.Space(10);
        GUILayout.Label(obj.GetType().Name);
        foreach (var field in typeof(T).GetFields())
        {
            GUILayout.Label(field.Name);
            if (field.FieldType == typeof(int))
            {
                var textField = EditorGUILayout.TextField($"{field.GetValue(obj)}");
                field.SetValue(obj, int.Parse(textField));
            }
            else if (field.FieldType == typeof(float))
            {
                var textField = EditorGUILayout.TextField($"{field.GetValue(obj)}");
                field.SetValue(obj, int.Parse(textField));
            }
            else if (field.FieldType == typeof(string))
            {
                var textField = EditorGUILayout.TextField($"{field.GetValue(obj)}");
                field.SetValue(obj, textField);
            }
            // 対応させたいenumを都度追加する
            else if(field.FieldType == typeof(CardAffectType))
            {
                var enumPopup = (CardAffectType)EditorGUILayout.EnumPopup((System.Enum)field.GetValue(obj));
                field.SetValue(obj, enumPopup);
            }
            else if(field.FieldType == typeof(BoardDeakAffectType))
            {
                var enumPopup = (BoardDeakAffectType)EditorGUILayout.EnumPopup((System.Enum)field.GetValue(obj));
                field.SetValue(obj, enumPopup);
            }
        }
    }
}