using Game.Root.UI;
using Game.MainMenu.MenuPanel;
using Zenject;
namespace Game.Root.EntryPoint
{
    public class MainMenuEntryPoint : IInitializable
    {
        readonly TabsHandler tabsHandler;
        public MainMenuEntryPoint(TabsHandler _tabsHandler)
        {
            tabsHandler = _tabsHandler;
        }
        public void Initialize()
        {
            tabsHandler.OpenTab<MainMenuModel>();
        }
    }
}
