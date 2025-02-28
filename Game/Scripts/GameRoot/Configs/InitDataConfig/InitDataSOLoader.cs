using Game.Root.AssetManagment;
using Cysharp.Threading.Tasks;

namespace Game.Root.Data.Initial
{
    class InitDataSOLoader : IInitDataLoader
    {
        readonly IAssetProvider assetProvider;
        DataInitStateSO dataInitSO;
        const string initialDataSOKey = "SavingInitialState";
        public InitDataSOLoader(IAssetProvider _assetProvider)
        {
            assetProvider = _assetProvider;
        }
        public async UniTask Prewarm()
        {
            dataInitSO = await assetProvider.LoadConfig<DataInitStateSO>(initialDataSOKey);
        }
        public ProgressData GetInitProgress()
        {
            return dataInitSO.InitialProgress;
        }
        public SettingsData GetInitSettings()
        {
            return dataInitSO.InitialSettings;
        }
    }
}
