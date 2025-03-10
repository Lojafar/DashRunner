﻿using Game.Root.UI.LoadingScreen;

namespace Game.Root.GameState.States.Params
{
    struct GameLoadingParam
    {
        public readonly LoadingScreenBase LoadingScreen;
        public readonly float LoadedPercent;

        public GameLoadingParam(LoadingScreenBase _loadingScreen, float _loadedPercent)
        {
            LoadingScreen = _loadingScreen;
            LoadedPercent = _loadedPercent;
        }
    }
}
