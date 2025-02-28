using Game.Root.ServiceInterfaces;
using Game.Root.UI.LoadingScreen;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Game.MainMenu.ShopPanel;
using Cysharp.Threading.Tasks;
using UnityEngine;
namespace Game.Root.UI
{
    public interface IUIFactory : IPrewarmableService
    {
        public UniTask<LoadingScreenBase> CreateBootLoadingScreen();
        public UniTask<MainMenuViewBase> CreateMainMenuView(Transform parent = null);
        public UniTask<MainSettingsViewBase> CreateMainSettingsView(Transform parent = null);
        public UniTask<LevelSelectionViewBase> CreateLevelSelectionView(Transform parent = null);
        public UniTask<ShopViewBase> CreateShopView(Transform parent = null);
    }
}