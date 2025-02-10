using Game.Root.AssetManagment;
using System.Threading.Tasks;

namespace Game.Root.GameConfig
{
    class GameConfigSOLoader : IGameConfigLoader
    {
        readonly IAssetProvider assetProvider;
        GameConfigSO configSO;
        const string configSOKey = "GameConfig";
        public GameConfigSOLoader(IAssetProvider _assetProvider)
        {
            assetProvider = _assetProvider;
        }
        public async Task Prewarm()
        {
            configSO = await assetProvider.LoadConfig<GameConfigSO>(configSOKey);
        }
        public GameConfig GetGameConfig()
        {
            return configSO.GameConfig;
        }
    }
}
