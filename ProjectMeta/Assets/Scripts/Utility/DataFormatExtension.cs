using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class DataFormatExtension
{
    public static T DeepCopy<T>(this T src)
    {
        using (var ms = new MemoryStream())
        {
            var binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(ms, src);
            ms.Seek(0, SeekOrigin.Begin);
            return (T)binaryFormatter.Deserialize(ms);
        }
    }
}