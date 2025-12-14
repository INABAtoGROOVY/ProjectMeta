using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardIllustSO", menuName = "Scriptable Objects/CardIllustSO")]
public class CardIllustSO : ScriptableObject
{
    public List<CardIllustData> DataList;
}