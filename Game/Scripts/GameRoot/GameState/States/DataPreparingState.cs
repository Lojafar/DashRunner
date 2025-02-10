using Game.Root.GameState.States.Params;
using Game.Root.SaveLoad;
using Game.Root.Data;
using Game.Root.Data.Initial;
using System.Threading.Tasks;

namespace Game.Root.GameState.States
{
    class DataPreparingState : IParamState<DataPreparingParam>
    {
        readonly GameStateMachine gameStateMachine;
        readonly ISaverLoader saverLoader;
        readonly AllDataContainer allDataContainer;
        readonly IInitDataLoader initDataLoaderBase;
        const float stateLoadingPercent = 0.3f;
        public DataPreparingState(GameStateMachine _gameStateMachine, ISaverLoader _saverLoader, AllDataContainer _allDataContainer, IInitDataLoader _initDataLoaderBase)
        {
            gameStateMachine = _gameStateMachine;
            saverLoader = _saverLoader;
            allDataContainer = _allDataContainer;
            initDataLoaderBase = _initDataLoaderBase;
        }
        public async void Enter(DataPreparingParam stateParam)
        {
            await LoadPlayerData();
            stateParam.LoadingScreen.UpdateProgress(stateParam.LoadedPercent + stateLoadingPercent);
            gameStateMachine.EnterState<AssetsLoadingState, AssetLoadingParams>(new AssetLoadingParams(stateParam.LoadingScreen,
                stateParam.LoadedPercent + stateLoadingPercent));
        }
        public async Task LoadPlayerData()
        {
            ProgressData progressDataInit = initDataLoaderBase.GetInitProgress();
            SettingsData settingsDataInit = initDataLoaderBase.GetInitSettings();
            ProgressData progressData = await saverLoader.LoadProgress();
            SettingsData settingsData = await saverLoader.LoadSettings();
            allDataContainer.ProgressData = progressData == null ? new ProgressDataProxy(progressDataInit) : 
                new ProgressDataProxy(progressData);
            allDataContainer.SettingsData = settingsData == null ? new SettingsDataProxy(settingsDataInit) :
                new SettingsDataProxy(settingsData, settingsDataInit);
        }
        public void Exit()
        {
        }
    }
}
