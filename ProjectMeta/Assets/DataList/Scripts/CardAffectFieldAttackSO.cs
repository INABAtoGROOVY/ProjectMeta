using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectFieldAttackSO", menuName = "Scriptable Objects/CardAffectFieldAttackSO")]
public class CardAffectFieldAttackSO : ScriptableObject
{
    public List<CardAffectFieldAttackSOData> FieldAttackDataList;
}

[Serializable]
public class CardAffectFieldAttackSOData : CardAffectSOData
{
    public float Power;
    public float Range;
}