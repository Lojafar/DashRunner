using Game.Root.GameState.States;
namespace Game.Root.GameState
{
    public interface IGameStatesFactory 
    {
        public T CreateState<T>() where T : IExitableState;
    }
}
