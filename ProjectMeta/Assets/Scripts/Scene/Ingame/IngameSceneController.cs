using System.ComponentModel.DataAnnotations;
using UnityEngine;

public class IngameSceneController : MonoBehaviour
{
    [SerializeField]
    private IngameView ingameView;

    private IngamePresenter ingamePresenter;

    public void Start()
    {
        ingamePresenter = new IngamePresenter(ingameView);
        ingamePresenter.ドロー();
    }

    public void OnDestroy()
    {
        ingamePresenter.Dispose();
    }
}