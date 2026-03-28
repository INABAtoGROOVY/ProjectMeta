using System;
using R3;

public class IngamePresenter : IDisposable
{
    private readonly CompositeDisposable _disposable = new();
    public ReactiveProperty<CardEntity> お試しカード = new ReactiveProperty<CardEntity>();

    private CardFactory cardFactory;

    private IIngameView ingameView;

    public IngamePresenter(IIngameView ingameView)
    {
        this.ingameView = ingameView;

        cardFactory = new CardFactory();

        お試しカード.Subscribe(_ =>
        {
            ingameView.UpdateDeck();
        }).AddTo(_disposable);
    }

    public void ドロー()
    {
        var card = cardFactory.Create(1);
        UnityEngine.Debug.Log(card.Name);
        お試しカード.Value = card;
    }

    public void Dispose()
    {
        _disposable.Dispose();
    }
}