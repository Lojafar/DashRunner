using Game.Root.ServiceInterfaces;
using Game.Root.UI;
using Game.Root.UI.LoadingScreen;
using Game.Root.GameState.States.Params;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Game.Root.GameState.States
{
    class BootState : IState
    {
        readonly GameStateMachine gameStateMachine;
        readonly List<IPrewarmableService> prewarmServices;
        readonly IUIFactory uiFactory;
        const float exitLoadingPercent = 0.1f;
        public BootState(GameStateMachine _gameStateMachine, List<IPrewarmableService> _prewarmServices, IUIFactory _uiFactory)
        {
            gameStateMachine = _gameStateMachine;
            prewarmServices = _prewarmServices;
            uiFactory = _uiFactory;
        }
        async Task WarmUpServices()
        {
            foreach (IPrewarmableService prewarmableService in prewarmServices)
            {
                await prewarmableService.Prewarm();
            }
        }
        public async void Enter()
        {
            await WarmUpServices();
            LoadingScreenBase loadingScreen = await PrepareLoadingScr();
            gameStateMachine.EnterState<DataPreparingState, DataPreparingParam>(new DataPreparingParam(loadingScreen, exitLoadingPercent));
        }
        async Task<LoadingScreenBase> PrepareLoadingScr()
        {
            LoadingScreenBase loadingScreen = await uiFactory.CreateBootLoadingScreen();
            loadingScreen.UpdateProgress(exitLoadingPercent);
            return loadingScreen;
        }

        public void Exit()
        {
        }
    }
}
