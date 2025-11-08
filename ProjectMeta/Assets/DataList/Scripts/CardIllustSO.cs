using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardIllustSO", menuName = "Scriptable Objects/CardIllustSO")]
public class CardIllustSO : ScriptableObject
{
    public List<CardIllustSOData> DataList;
}

[Serializable]
public class CardIllustSOData
{
    public int Id;
    public string Name;
    public Sprite Image;
}