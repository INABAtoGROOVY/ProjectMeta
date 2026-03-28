using System.Collections.Generic;
using UnityEngine;

//TODO SOBase対応
[CreateAssetMenu(fileName = "CardAffectFieldAttackSO", menuName = "Scriptable Objects/CardAffectFieldAttackSO")]
public class CardAffectFieldAttackSO : ScriptableObject
{
    public List<CardAffectFieldAttackData> FieldAttackDataList;
}