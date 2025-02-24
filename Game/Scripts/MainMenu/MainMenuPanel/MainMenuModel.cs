using Game.Root.UI;
using Game.Root.UI.Tabs;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Game.MainMenu.ShopPanel;
namespace Game.MainMenu.MenuPanel
{
    public class MainMenuModel : TabModel
    {
        readonly TabsHandler tabsHandler;
        public MainMenuModel(TabsHandler _tabsHandler)
        {
            tabsHandler = _tabsHandler;
        }
        public void OnOpenLevelsInput()
        {
            tabsHandler.OpenTab<LevelSelectionModel>();
        }
        public void OnOpenSettingsInput()
        {
            tabsHandler.OpenTab<MainSettingsModel>();
        }
        public void OnOpenShopInput()
        {
            tabsHandler.OpenTab<ShopModel>();
        }
    }
}
