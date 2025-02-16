﻿using Game.Root.UI.LoadingScreen;

namespace Game.Root.GameState.States.Params
{
    struct DataPreparingParam
    {
        public readonly LoadingScreenBase LoadingScreen;
        public readonly float LoadedPercent;
        public DataPreparingParam(LoadingScreenBase _loadingScreen, float _loadedPercent)
        {
            LoadingScreen = _loadingScreen;
            LoadedPercent = _loadedPercent;
        }
    }
}
