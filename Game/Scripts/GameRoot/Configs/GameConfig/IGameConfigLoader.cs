using Game.Root.ServiceInterfaces;

namespace Game.Root.GameConfig
{
    public interface IGameConfigLoader : IPrewarmableService
    {
        public GameConfig GetGameConfig();
    }
}
