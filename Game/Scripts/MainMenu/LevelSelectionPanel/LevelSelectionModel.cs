using Game.Root.Data;
using Game.Root.GameConfig;
using Game.Root.SceneManagment;
using Game.Root.EntryPoint.EntryParams;
using Game.Root.UI;
using Game.Root.UI.Tabs;
using Game.MainMenu.MenuPanel;
using R3;
namespace Game.MainMenu.LevelSelectionPanel
{
    public class LevelSelectionModel : TabModel
    {
        public readonly Subject<int> CreateLevelsEvent;
        public readonly Subject<LevelProgress> LevelInitEvent;
        readonly AllDataContainer allDataContainer;
        readonly GameConfig gameConfig;
        readonly IScenesLoader scenesLoader;
        readonly TabsHandler tabsHandler;
        public LevelSelectionModel(AllDataContainer _allDataContainer, IGameConfigLoader _gameConfigLoader, IScenesLoader _scenesLoader, TabsHandler _tabsHandler)
        {
            allDataContainer = _allDataContainer;
            gameConfig = _gameConfigLoader.GetGameConfig();
            scenesLoader = _scenesLoader;
            tabsHandler = _tabsHandler;
            CreateLevelsEvent = new Subject<int>();
            LevelInitEvent = new Subject<LevelProgress>();
        }
        public void InitAllLevels()
        {
            CreateLevelsEvent.OnNext(gameConfig.LevelsCount);
        }
        public void InitSavedLevels()
        {
            foreach (LevelProgress levelProgress in allDataContainer.ProgressData.DataOrigin.LevelsProgresses)
            {
                LevelInitEvent.OnNext(levelProgress);
            }
        }
        public void OnBackInput()
        {
            tabsHandler.OpenTab<MainMenuModel>();
        }
        public void OnLevelInput(int levelNumber)
        {
            if (levelNumber < 0) return;
            GameSceneEntryParam gameEntryParam = new(levelNumber);
            EntryParamHolder.CurrentEntryParam = gameEntryParam;
            scenesLoader.LoadScene(Scenes.GamePlay);
        }
    }
}
