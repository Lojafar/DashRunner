using Game.Root.ServiceInterfaces;
using Game.Root.UI.LoadingScreen;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using System.Threading.Tasks;
namespace Game.Root.UI
{
    public interface IUIFactory : IPrewarmableService
    {
        public Task<LoadingScreenBase> CreateBootLoadingScreen();
        public Task<MainMenuViewBase> CreateMainMenuView();
        public Task<MainSettingsViewBase> CreateMainSettingsView();
        public Task<LevelSelectionViewBase> CreateLevelSelectionView();
    }
}