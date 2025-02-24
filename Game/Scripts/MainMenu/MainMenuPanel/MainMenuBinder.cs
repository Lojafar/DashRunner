using Game.Root.UI;

namespace Game.MainMenu.MenuPanel
{
    class MainMenuBinder
    {
        MainMenuViewBase mainMenuView;
        readonly MainMenuModel mainMenuModel;
        readonly TabsHandler tabsHandler;
        readonly MainMenuInstances mainMenuInstances;
        public MainMenuBinder(IUIFactory _uiFactory, TabsHandler _tabsHandler, MainMenuInstances _mainMenuInstances)
        {
            tabsHandler = _tabsHandler;
            mainMenuInstances = _mainMenuInstances;
            mainMenuModel = new MainMenuModel(tabsHandler);

            CreateAndBindView(_uiFactory);
        }
        public async void CreateAndBindView(IUIFactory uiFactory)
        {
            mainMenuView = await uiFactory.CreateMainMenuView(mainMenuInstances.MainMenuCanvas.transform);
            BindView();
        }
        void BindView()
        {
            MainMenuVM mainMenuVM = new(mainMenuModel);
            mainMenuVM.Init();

            mainMenuView.Bind(mainMenuVM);

            tabsHandler.RegisterTabModel(mainMenuModel);
        }
    }
}
