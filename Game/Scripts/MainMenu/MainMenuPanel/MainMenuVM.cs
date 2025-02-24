using System;
using R3;
namespace Game.MainMenu.MenuPanel
{
    public class MainMenuVM
    {
        readonly MainMenuModel menuModel;
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> PlayGameInputEvent;
        public readonly Subject<Unit> SettingsInputEvent;
        public readonly Subject<Unit> ShopInputEvent;
        readonly CompositeDisposable subscriptions;
        public MainMenuVM(MainMenuModel _menuModel)
        {
            menuModel = _menuModel;
            OpeningEvent = menuModel.OpeningEvent;
            ClosingEvent = menuModel.ClosingEvent;
            PlayGameInputEvent = new Subject<Unit>();
            SettingsInputEvent = new Subject<Unit>();
            ShopInputEvent = new Subject<Unit>();
            subscriptions = new CompositeDisposable();
        }
        public void Init()
        {
            PlayGameInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => menuModel.OnOpenLevelsInput()).AddTo(subscriptions);
            SettingsInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => menuModel.OnOpenSettingsInput()).AddTo(subscriptions);
            ShopInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => menuModel.OnOpenShopInput()).AddTo(subscriptions);
        }
    }
}
