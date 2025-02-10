using Game.Root.AssetManagment;
using Game.Root.UI.LoadingScreen;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
namespace Game.Root.UI
{
    class UIFactory : IUIFactory
    {
        IAssetProvider assetProvider;
        readonly DiContainer container;
        Canvas uiRoot;
        public UIFactory(DiContainer _container)
        {
            container = _container;
        }
        public async Task Prewarm()
        {
            assetProvider = container.Resolve<IAssetProvider>();
            await CreateUIRoot();
        }
        async Task CreateUIRoot()
        {
            Canvas uiRootPrefab = await assetProvider.LoadPrefab<Canvas>(AssetsKeys.UIRootKey);
            uiRoot = Object.Instantiate(uiRootPrefab);
            Object.DontDestroyOnLoad(uiRoot);
        }
        public async Task<LoadingScreenBase> CreateBootLoadingScreen()
        {
            return await CreateUI<LoadingScreenBase>(AssetsKeys.BootLoadingScreen);
        }
        public async Task<MainMenuViewBase> CreateMainMenuView()
        {
            return await CreateUI<MainMenuViewBase>(AssetsKeys.MainMenuKey);
        }
        public async Task<MainSettingsViewBase> CreateMainSettingsView()
        {
            return await CreateUI<MainSettingsViewBase>(AssetsKeys.MainSettingsKey);
        }
        public async Task<LevelSelectionViewBase> CreateLevelSelectionView()
        {
            return await CreateUI<LevelSelectionViewBase>(AssetsKeys.LevelSelectionKey);
        }
        async Task<T> CreateUI<T>(string Key) where T : MonoBehaviour
        {
            T prefab = await assetProvider.LoadPrefab<T>(Key);
            return Object.Instantiate(prefab, uiRoot.transform, false);
        }
    }
}
