using Game.Root.Data;
using Game.Root.GameConfig;
using Game.Root.UI;

namespace Game.MainMenu.LevelSelectionPanel
{
    class LevelSelectionBinder
    {
        LevelSelectionViewBase lvlSelectionView;
        readonly LevelSelectionModel model;
        readonly TabsHandler tabsHandler;
        public LevelSelectionBinder(AllDataContainer _allDataContainer, IGameConfigLoader _gameConfigLoader, TabsHandler _tabsHandler, IUIFactory _uiFactory)
        {
            tabsHandler = _tabsHandler;
            model = new LevelSelectionModel(_allDataContainer, _gameConfigLoader, tabsHandler);

            CreateAndBindView(_uiFactory);
        }
        async void CreateAndBindView(IUIFactory uiFactory)
        {
            lvlSelectionView = await uiFactory.CreateLevelSelectionView();
            Bind();
        }
        void Bind()
        {
            LevelSelectionVM lvlSelectionVM = new(model);
            lvlSelectionView.Bind(lvlSelectionVM);
            tabsHandler.RegisterTabModel(model);

            model.InitAllLevels();
        }
    }
}
