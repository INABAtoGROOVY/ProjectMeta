using System;
using UnityEditor;
using UnityEngine;

public class CommonPopupEditorWindow : EditorWindow
{
    public static void Open(
        string title,
        string message,
        string okText,
        string cancelText,
        Action okCallBack = null,
        Action cancelCallBack = null
    )
    {
        EditorApplication.Beep();
        bool option = EditorUtility.DisplayDialog(title,message,okText,cancelText);
        if (option)
        {
            okCallBack?.Invoke();
        }
        else
        {
            cancelCallBack?.Invoke();
        }
    }
}