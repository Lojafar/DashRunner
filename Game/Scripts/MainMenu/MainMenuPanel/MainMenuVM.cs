using System;
using R3;
namespace Game.MainMenu.MenuPanel
{
    public class MainMenuVM
    {
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> PlayGameInputEvent;
        public readonly Subject<Unit> SettingsInputEvent;
        public MainMenuVM(MainMenuModel menuModel)
        {
            OpeningEvent = menuModel.OpeningEvent;
            ClosingEvent = menuModel.ClosingEvent;
            PlayGameInputEvent = new Subject<Unit>();
            SettingsInputEvent = new Subject<Unit>();
            PlayGameInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => menuModel.OnPlayGameInput());
            SettingsInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => menuModel.OnOpenSettingsInput());
        }
    }
}
