using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardSO", menuName = "Scriptable Objects/CardSO")]
public class CardSO : ScriptableObject
{
    public List<CardSOData> DataList;
}

[Serializable]
public class CardSOData
{
    public int Id;
    public int CardAffectId;
    public int IllustId;
    public string Name;
}