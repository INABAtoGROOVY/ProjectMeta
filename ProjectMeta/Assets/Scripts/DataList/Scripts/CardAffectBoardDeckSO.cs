using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectBoardDeckSO", menuName = "Scriptable Objects/CardAffectBoardDeckSO")]
public class CardAffectBoardDeckSO : ScriptableObject
{
    public List<CardAffectBoardDeckData> BoardDeckDataList;
}