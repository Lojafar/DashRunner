using Game.Root.UI;
using Game.Root.SaveLoad;
using Game.Root.Data;

namespace Game.MainMenu.SettingsPanel
{
    class MainSettingsBinder
    {
        MainSettingsViewBase settingsView;
        readonly MainSettingsModel settingsModel;
        readonly TabsHandler tabsHandler;
        readonly AllDataContainer allDataContainer;
        readonly ISaverLoader saverLoader;
        readonly MainMenuInstances mainMenuInstances;
        public MainSettingsBinder(TabsHandler _tabsHandler, IUIFactory _uiFactory, AllDataContainer _allDataContainer, ISaverLoader _saverLoader, MainMenuInstances _mainMenuInstances)
        {
            tabsHandler = _tabsHandler;
            allDataContainer = _allDataContainer;
            saverLoader = _saverLoader;
            mainMenuInstances = _mainMenuInstances;
            settingsModel = new MainSettingsModel(tabsHandler, allDataContainer, saverLoader);

            CreateAndBindView(_uiFactory);
        }
        async void CreateAndBindView(IUIFactory uiFactory)
        {
            settingsView = await uiFactory.CreateMainSettingsView(mainMenuInstances.MainMenuCanvas.transform);
            Bind();
        }
        void Bind()
        {
            MainSettingsVM settingsVM = new(settingsModel);
            settingsVM.Init();
            settingsView.Bind(settingsVM);

            tabsHandler.RegisterTabModel(settingsModel);
        }
    }
}
