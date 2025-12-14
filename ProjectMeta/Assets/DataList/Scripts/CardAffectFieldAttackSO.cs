using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardAffectFieldAttackSO", menuName = "Scriptable Objects/CardAffectFieldAttackSO")]
public class CardAffectFieldAttackSO : ScriptableObject
{
    public List<CardAffectFieldAttackData> FieldAttackDataList;
}