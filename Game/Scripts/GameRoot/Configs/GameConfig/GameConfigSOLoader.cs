using Game.Root.AssetManagment;
using Cysharp.Threading.Tasks;

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
        public async UniTask Prewarm()
        {
            configSO = await assetProvider.LoadConfig<GameConfigSO>(configSOKey);
        }
        public GameConfig GetGameConfig()
        {
            return configSO.GameConfig;
        }
    }
}
