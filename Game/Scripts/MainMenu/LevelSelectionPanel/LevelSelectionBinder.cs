using Game.Root.Data;
using Game.Root.GameConfig;
using Game.Root.SceneManagment;
using Game.Root.UI;
using Zenject;
namespace Game.MainMenu.LevelSelectionPanel
{
    class LevelSelectionBinder : IInitializable
    {
        LevelSelectionViewBase lvlSelectionView;
        readonly LevelSelectionModel model;
        readonly TabsHandler tabsHandler;
        readonly IUIFactory uiFactory;
        readonly MainMenuInstances mainMenuInstances;
        public LevelSelectionBinder(AllDataContainer _allDataContainer, IGameConfigLoader _gameConfigLoader, IScenesLoader _scenesLoader, 
            TabsHandler _tabsHandler, IUIFactory _uiFactory, MainMenuInstances _mainMenuInstances)
        {
            tabsHandler = _tabsHandler;
            uiFactory = _uiFactory;
            mainMenuInstances = _mainMenuInstances;
            model = new LevelSelectionModel(_allDataContainer, _gameConfigLoader, _scenesLoader, tabsHandler);
            CreateAndBindView();


        }
        public void Initialize()
        {
         //   CreateAndBindView();
        }
        async void CreateAndBindView()
        {
            lvlSelectionView = await uiFactory.CreateLevelSelectionView(mainMenuInstances.MainMenuCanvas.transform);
            Bind();
        }
        void Bind()
        {
            LevelSelectionVM lvlSelectionVM = new(model);
            lvlSelectionVM.Init();
            lvlSelectionView.Bind(lvlSelectionVM);
            tabsHandler.RegisterTabModel(model);
            model.InitAllLevels();
        }

       
    }
}
