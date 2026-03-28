using System;
using UnityEngine;

[Serializable]
public class CardIllustData
{
    public int Id;
    public string Name;
    public Sprite Image;

    public CardIllustData() { }

    public CardIllustData(int id, string name, Sprite image)
    {
        Id = id;
        Name = name;
        Image = image;
    }
}