using System.Collections.Generic;
using UnityEngine;

//TODO SOBase対応
[CreateAssetMenu(fileName = "CardAffectFieldSummonSO", menuName = "Scriptable Objects/CardAffectFieldSummonSO")]
public class CardAffectFieldSummonSO : ScriptableObject
{
    public List<CardAffectFieldSummonData> FieldSummonDataList;
}