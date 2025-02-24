using Game.Root.ServiceInterfaces;
using Game.Root.UI.LoadingScreen;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Game.MainMenu.ShopPanel;
using System.Threading.Tasks;
using UnityEngine;
namespace Game.Root.UI
{
    public interface IUIFactory : IPrewarmableService
    {
        public Task<LoadingScreenBase> CreateBootLoadingScreen();
        public Task<MainMenuViewBase> CreateMainMenuView(Transform parent = null);
        public Task<MainSettingsViewBase> CreateMainSettingsView(Transform parent = null);
        public Task<LevelSelectionViewBase> CreateLevelSelectionView(Transform parent = null);
        public Task<ShopViewBase> CreateShopView(Transform parent = null);
    }
}