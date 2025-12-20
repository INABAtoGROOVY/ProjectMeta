using System.ComponentModel.DataAnnotations;
using UnityEngine;

public class IngameSceneController : MonoBehaviour
{
    [SerializeField]
    private CardFactory cardFactory;

    [SerializeField]
    private IngameView ingameView;

    private IngamePresenter ingamePresenter;

    public void Start()
    {
        ingamePresenter = new IngamePresenter(cardFactory, ingameView);
        ingamePresenter.ドロー();
    }

    public void OnDestroy()
    {
        ingamePresenter.Dispose();
    }
}