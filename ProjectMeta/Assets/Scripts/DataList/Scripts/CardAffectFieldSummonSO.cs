using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectFieldSummonSO", menuName = "Scriptable Objects/CardAffectFieldSummonSO")]
public class CardAffectFieldSummonSO : ScriptableObject
{
    public List<CardAffectFieldSummonData> FieldSummonDataList;
}