using Game.Root.Data;
using System.Threading.Tasks;

namespace Game.Root.SaveLoad
{
    public interface ISaverLoader
    {
        public Task SaveProgress(ProgressData progress);
        public Task<ProgressData> LoadProgress();
        public Task SaveSettings(SettingsData settings);
        public Task<SettingsData> LoadSettings();
    }
}
