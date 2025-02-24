using Game.Root.UI;

namespace Game.MainMenu.ShopPanel
{
    class ShopTabBinder
    {
        ShopViewBase shopView;
        readonly ShopModel shopModel;
        readonly TabsHandler tabsHandler;
        readonly MainMenuInstances mainMenuInstances;
        public ShopTabBinder(IUIFactory _uiFactory, TabsHandler _tabsHandler, MainMenuInstances _mainMenuInstances)
        {
            tabsHandler = _tabsHandler;
            mainMenuInstances = _mainMenuInstances;
            shopModel = new ShopModel(tabsHandler);
            CreateAndBindView(_uiFactory);
        }
        async void CreateAndBindView(IUIFactory uiFactory)
        {
            shopView = await uiFactory.CreateShopView(mainMenuInstances.MainMenuCanvas.transform);
            Bind();
        }
        void Bind()
        {
            ShopVM shopVM = new(shopModel);
            shopVM.Init();
            shopView.Bind(shopVM);

            tabsHandler.RegisterTabModel(shopModel);
        }
    }
}
