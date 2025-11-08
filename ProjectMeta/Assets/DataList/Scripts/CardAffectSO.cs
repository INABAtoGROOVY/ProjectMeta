using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectSO", menuName = "Scriptable Objects/CardAffectSO")]
public class CardAffectSO : ScriptableObject
{
    public List<CardAffectBoardDeckSOData> BoardDeckDataList;
    public List<CardAffectFieldSummonSOData> FieldSummonDataList;
    public List<CardAffectFieldAttackSOData> FieldAttackDataList;
}

public abstract class CardAffectSOData
{
    public int Id;
    public string Name;
    public int Cost;
}

[Serializable]
public class CardAffectBoardDeckSOData : CardAffectSOData
{
    //TODO
}

[Serializable]
public class CardAffectFieldSummonSOData : CardAffectSOData
{
    //TODO
}

[Serializable]
public class CardAffectFieldAttackSOData : CardAffectSOData
{
    //TODO
}