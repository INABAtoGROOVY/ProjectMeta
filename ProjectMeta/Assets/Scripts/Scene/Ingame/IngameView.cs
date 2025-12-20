using UnityEngine;

public class IngameView : MonoBehaviour,IIngameView
{
    public void UpdateDeck()
    {
        Debug.Log("updatedeck");
    }
}
