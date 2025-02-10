using System;
using R3;
namespace Game.MainMenu.SettingsPanel
{
    public class MainSettingsVM
    {
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> BackInputEvent;
        public readonly ReactiveProperty<float> MusicVolume;
        public readonly ReactiveProperty<float> SFXVolume;

        const float maxVolume = 1;
        const float minVolume = 0;
        public MainSettingsVM(MainSettingsModel model)
        {
            OpeningEvent = model.OpeningEvent;
            ClosingEvent = model.ClosingEvent;
            BackInputEvent = new();
            MusicVolume = new();
            SFXVolume = new();
            model.MusicVolume.Subscribe(volume => MusicVolume.Value = volume);
            model.SoundsVolume.Subscribe(volume => SFXVolume.Value = volume);
            BackInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => model.OnBackInput());
            MusicVolume.Skip(1).Subscribe(newVolume =>
            {
                CheckAndCorrectVolume(ref newVolume);
                model.SetMusicVolume(newVolume);
            });
            SFXVolume.Skip(1).Subscribe(newVolume =>
            {
                CheckAndCorrectVolume(ref newVolume);
                model.SetSFXVolume(newVolume);
            });
        }
        void CheckAndCorrectVolume(ref float volume)
        {
            if (volume < minVolume) volume = minVolume;
            else if (volume > maxVolume) volume = maxVolume;
        }
    }
}
