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
        public MainSettingsBinder(TabsHandler _tabsHandler, IUIFactory _uiFactory, AllDataContainer _allDataContainer, ISaverLoader _saverLoader)
        {
            tabsHandler = _tabsHandler;
            allDataContainer = _allDataContainer;
            saverLoader = _saverLoader;

            settingsModel = new MainSettingsModel(tabsHandler, allDataContainer, saverLoader);

            CreateAndBindView(_uiFactory);
        }
        async void CreateAndBindView(IUIFactory uiFactory)
        {
            settingsView = await uiFactory.CreateMainSettingsView();
            Bind();
        }
        void Bind()
        {
            MainSettingsVM settingsVM = new(settingsModel);
            settingsView.Bind(settingsVM);

            tabsHandler.RegisterTabModel(settingsModel);
        }
    }
}
