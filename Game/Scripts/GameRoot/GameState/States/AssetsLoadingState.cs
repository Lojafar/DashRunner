using Game.Root.GameState.States.Params;
using Game.Root.AssetManagment;
using Game.MainMenu.MenuPanel;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Root.GameState.States
{
    class AssetsLoadingState : IParamState<AssetLoadingParams>
    {
        readonly GameStateMachine gameStateMachine;
        readonly IAssetProvider assetProvider;
        const float stateLoadingPercent = 0.3f;
        public AssetsLoadingState(GameStateMachine _gameStateMachine, IAssetProvider _assetProvider)
        {
            gameStateMachine = _gameStateMachine;
            assetProvider = _assetProvider;
        }
        public async void Enter(AssetLoadingParams param)
        {
            await LoadAssets();
            param.LoadingScreen.UpdateProgress(param.LoadedPercent + stateLoadingPercent);
            gameStateMachine.EnterState<GameLoadingState, GameLoadingParam>(new GameLoadingParam(param.LoadingScreen,
               param.LoadedPercent + stateLoadingPercent));
        }
        async Task LoadAssets()
        {
            await assetProvider.LoadPrefab<Canvas>(AssetsKeys.UIRootKey);
            await assetProvider.LoadPrefab<MainMenuViewBase>(AssetsKeys.MainMenuKey);
        }
        public void Exit()
        {

        }
    }
}
