using System;
namespace Game.Root.Data
{
    [Serializable]
    public class SettingsData
    {
        public float MusicVolume = -1;
        public float SoundsVolume = -1;
        public SettingsData Clone()
        {
            return new SettingsData { MusicVolume = this.MusicVolume, SoundsVolume = this.SoundsVolume };
        }
    }
}
