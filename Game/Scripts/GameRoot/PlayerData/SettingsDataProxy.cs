using R3;

namespace Game.Root.Data
{
    public class SettingsDataProxy
    {
        public ReactiveProperty<float> MusicVolume { get; private set; }
        public ReactiveProperty<float> SoundsVolume { get; private set; }
        public SettingsData dataOrigin;
        public SettingsData DataOrigin => dataOrigin.Clone();

        const float maxVolume = 1;
        const float minVolume = 0;
        public SettingsDataProxy(SettingsData _settingsData)
        {
            Constructor(_settingsData);
        }
        public SettingsDataProxy(SettingsData _settingsData, SettingsData _settingsDataInit)
        {
            if (_settingsData.MusicVolume < 0) _settingsData.MusicVolume = _settingsDataInit.MusicVolume;
            if (_settingsData.SoundsVolume < 0) _settingsData.SoundsVolume = _settingsDataInit.SoundsVolume;

            Constructor(_settingsData);
        }
        void Constructor(SettingsData _settingsData)
        {
            dataOrigin = _settingsData;
            MusicVolume = new ReactiveProperty<float>();
            SoundsVolume = new ReactiveProperty<float>();
        }
        public void Init()
        {
            MusicVolume.Value = dataOrigin.MusicVolume;
            SoundsVolume.Value = dataOrigin.SoundsVolume;
            MusicVolume.Skip(1).Subscribe(newVolume =>
            {
                if (CheckVolume(newVolume)) dataOrigin.MusicVolume = newVolume;
            });
            SoundsVolume.Skip(1).Subscribe(newVolume =>
            {
                if (CheckVolume(newVolume)) dataOrigin.SoundsVolume = newVolume;
            });
        }
        bool CheckVolume(float volume)
        {
            return volume >= minVolume && volume <= maxVolume;
        }
    }
}
