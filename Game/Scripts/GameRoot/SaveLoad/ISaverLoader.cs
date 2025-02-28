using Game.Root.Data;
using Cysharp.Threading.Tasks;

namespace Game.Root.SaveLoad
{
    public interface ISaverLoader
    {
        public UniTask SaveProgress(ProgressData progress);
        public UniTask<ProgressData> LoadProgress();
        public UniTask SaveSettings(SettingsData settings);
        public UniTask<SettingsData> LoadSettings();
    }
}
