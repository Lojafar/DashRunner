using Game.Root.UI;
using Game.Root.UI.Tabs;
using Game.MainMenu.MenuPanel;
namespace Game.MainMenu.ShopPanel
{
    public class ShopModel : TabModel
    {
        readonly TabsHandler tabsHandler;
        public ShopModel(TabsHandler _tabsHandler) 
        {
            tabsHandler = _tabsHandler;
        }
        public void OnBackInput()
        {
            tabsHandler.OpenTab<MainMenuModel>();
        }
    }
}
