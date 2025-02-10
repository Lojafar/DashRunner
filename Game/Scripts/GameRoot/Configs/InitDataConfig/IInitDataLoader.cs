using Game.Root.ServiceInterfaces;
namespace Game.Root.Data.Initial 
{
    public interface IInitDataLoader : IPrewarmableService
    {
        public ProgressData GetInitProgress();
        public SettingsData GetInitSettings();
    }
}
