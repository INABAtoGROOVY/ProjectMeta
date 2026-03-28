using System.Collections.Generic;
using UnityEngine;

//TODO SOBase対応
[CreateAssetMenu(fileName = "CardAffectBoardDeckSO", menuName = "Scriptable Objects/CardAffectBoardDeckSO")]
public class CardAffectBoardDeckSO : ScriptableObject
{
    public List<CardAffectBoardDeckData> BoardDeckDataList;
}