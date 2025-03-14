﻿using Game.Root.SceneManagment;
using Game.Root.AssetManagment;
using Game.Root.Audio;
using Game.Root.GameState.States.Params;
using UnityEngine;

namespace Game.Root.GameState.States
{
    class GameLoadingState : IParamState<GameLoadingParam>
    {
        readonly GameStateMachine gameStateMachine;
        readonly IScenesLoader scenesLoader;
        readonly IAssetProvider assetProvider;
        readonly IAudioPlayer<AudioClip> audioPlayer;
        const float stateLoadingPercent = 1f;
        const string BGMusicPath = "Audio/BackGroundMusic";
        public GameLoadingState(GameStateMachine _gameStateMachine, IScenesLoader _scenesLoader, IAssetProvider _assetProvider, IAudioPlayer<AudioClip> _audioPlayer)
        {
            gameStateMachine = _gameStateMachine;
            scenesLoader = _scenesLoader;
            assetProvider = _assetProvider;
            audioPlayer = _audioPlayer;
        }
        public async void Enter(GameLoadingParam stateParam)
        {
            AudioClip bgMusic = await assetProvider.LoadAsset<AudioClip>(BGMusicPath);
            audioPlayer.Init();
            audioPlayer.SetBGMusic(bgMusic);
            scenesLoader.LoadScene(Scenes.MainMenu,
               completeCallback: () =>
               {
                   OnSceneLoaded(stateParam);
               },
               progressUpdate: (sceneProgress) => 
               {
                   stateParam.LoadingScreen.UpdateProgress(stateParam.LoadedPercent + sceneProgress * 
                       (stateLoadingPercent - stateParam.LoadedPercent));
               });
        }
        void OnSceneLoaded(GameLoadingParam stateParam)
        {
            Object.Destroy(stateParam.LoadingScreen.gameObject);
            gameStateMachine.EnterState<GameplayState>();
        }

        public void Exit()
        {
        }
    }
}
