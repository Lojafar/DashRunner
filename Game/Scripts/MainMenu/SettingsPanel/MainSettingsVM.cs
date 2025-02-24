using System;
using R3;
namespace Game.MainMenu.SettingsPanel
{
    public class MainSettingsVM
    {
        readonly MainSettingsModel settingsModel;
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> BackInputEvent;
        public readonly ReactiveProperty<float> MusicVolume;
        public readonly ReactiveProperty<float> SFXVolume;
        readonly CompositeDisposable subscriptions;

        const float maxVolume = 1;
        const float minVolume = 0;
        public MainSettingsVM(MainSettingsModel _model)
        {
            settingsModel = _model;
            OpeningEvent = settingsModel.OpeningEvent;
            ClosingEvent = settingsModel.ClosingEvent;
            BackInputEvent = new();
            MusicVolume = new();
            SFXVolume = new();
            subscriptions = new CompositeDisposable();
        }
        public void Init()
        {
            settingsModel.MusicVolume.Subscribe(volume => MusicVolume.Value = volume).AddTo(subscriptions);
            settingsModel.SoundsVolume.Subscribe(volume => SFXVolume.Value = volume).AddTo(subscriptions);
            BackInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => settingsModel.OnBackInput()).AddTo(subscriptions);
            MusicVolume.Skip(1).Subscribe(newVolume =>
            {
                CheckAndCorrectVolume(ref newVolume);
                settingsModel.SetMusicVolume(newVolume);
            }).AddTo(subscriptions);

            SFXVolume.Skip(1).Subscribe(newVolume =>
            {
                CheckAndCorrectVolume(ref newVolume);
                settingsModel.SetSFXVolume(newVolume);
            }).AddTo(subscriptions);

        }
        void CheckAndCorrectVolume(ref float volume)
        {
            if (volume < minVolume) volume = minVolume;
            else if (volume > maxVolume) volume = maxVolume;
        }
    }
}
