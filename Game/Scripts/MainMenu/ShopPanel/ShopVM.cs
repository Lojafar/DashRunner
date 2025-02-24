using System;
using R3;
namespace Game.MainMenu.ShopPanel
{
    public class ShopVM
    {
        readonly ShopModel shopModel;
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> BackInputEvent;
        readonly CompositeDisposable subscriptions;
        public ShopVM(ShopModel _model)
        {
            shopModel = _model;
            OpeningEvent = shopModel.OpeningEvent;
            ClosingEvent = shopModel.ClosingEvent;
            BackInputEvent = new Subject<Unit>();
            subscriptions = new CompositeDisposable();
        }
        public void Init()
        {
            BackInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => shopModel.OnBackInput()).AddTo(subscriptions);
        }
    }
}
