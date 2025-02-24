using Game.Root.AssetManagment;
using Game.Root.UI.LoadingScreen;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Game.MainMenu.ShopPanel;
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
        public async Task<MainMenuViewBase> CreateMainMenuView(Transform parent = null)
        {
            return await CreateUI<MainMenuViewBase>(AssetsKeys.MainMenuKey, parent);
        }
        public async Task<MainSettingsViewBase> CreateMainSettingsView(Transform parent = null)
        {
            return await CreateUI<MainSettingsViewBase>(AssetsKeys.MainSettingsKey, parent);
        }
        public async Task<LevelSelectionViewBase> CreateLevelSelectionView(Transform parent = null)
        {
            return await CreateUI<LevelSelectionViewBase>(AssetsKeys.LevelSelectionKey, parent);
        }
        public async Task<ShopViewBase> CreateShopView(Transform parent = null)
        {
            return await CreateUI<ShopViewBase>(AssetsKeys.ShopViewKey, parent);
        }
        async Task<T> CreateUI<T>(string Key, Transform parent = null) where T : MonoBehaviour
        {
            T prefab = await assetProvider.LoadPrefab<T>(Key);
            Transform objParent = parent == null ? uiRoot.transform : parent;
            return Object.Instantiate(prefab, objParent, false);
        }
    }
}
