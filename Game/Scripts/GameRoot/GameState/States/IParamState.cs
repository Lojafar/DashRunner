﻿namespace Game.Root.GameState.States
{
    public interface IParamState<TParam> : IExitableState
    {
        public void Enter(TParam param);
    }
}
