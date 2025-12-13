using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectBoardDeckSO", menuName = "Scriptable Objects/CardAffectBoardDeckSO")]
public class CardAffectBoardDeckSO : ScriptableObject
{
    public List<CardAffectBoardDeckSOData> BoardDeckDataList;
}

[Serializable]
public class CardAffectBoardDeckSOData : CardAffectSOData
{
    //TODO
}