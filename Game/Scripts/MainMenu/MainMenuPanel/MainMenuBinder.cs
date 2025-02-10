using Game.Root.UI;

namespace Game.MainMenu.MenuPanel
{
    class MainMenuBinder
    {
        MainMenuViewBase mainMenuView;
        readonly MainMenuModel mainMenuModel;
        readonly TabsHandler tabsHandler;
        public MainMenuBinder(IUIFactory _uiFactory, TabsHandler _tabsHandler)
        {
            tabsHandler = _tabsHandler;

            mainMenuModel = new MainMenuModel(tabsHandler);

            CreateAndBindView(_uiFactory);
        }
        public async void CreateAndBindView(IUIFactory uiFactory)
        {
            mainMenuView = await uiFactory.CreateMainMenuView();
            BindView();
        }
        void BindView()
        {
            MainMenuVM mainMenuVM = new(mainMenuModel);
            mainMenuView.Bind(mainMenuVM);

            tabsHandler.RegisterTabModel(mainMenuModel);
        }
    }
}
