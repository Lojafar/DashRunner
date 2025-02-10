using Game.Root.GameState;
using Game.Root.UI;
using Game.Root.Audio;
using Game.Root.SceneManagment;
using Game.Root.AssetManagment;
using Game.Root.SaveLoad;
using Game.Root.Data;
using Game.Root.Data.Initial;
using Game.Root.GameConfig;
using Game.Utils;
using Zenject;
using UnityEngine;

namespace Game.Root.Installers
{
    class RootInstaller : MonoInstaller
    {
        [SerializeField] AudioSourcesHolder audioSourcesHolder;
        public override void InstallBindings()
        {
            BindInstances();
            BindFactories();
            BindServices();
        }
        void BindInstances()
        {
            CreateAndBindCoros();
            Container.Bind<AudioSourcesHolder>().FromInstance(audioSourcesHolder).AsSingle();
        }
        void CreateAndBindCoros()
        {
            Coroutines coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            DontDestroyOnLoad(coroutines);
            Container.Bind<Coroutines>().FromInstance(coroutines).AsSingle();
        }
        void BindFactories()
        {
            Container.Bind<IGameStatesFactory>().To<GameStatesFactory>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UIFactory>().AsSingle().NonLazy();
        }
        void BindServices()
        {
            Container.Bind<IScenesLoader>().To<ScenesLoader>().AsSingle().NonLazy();
            Container.Bind<IAssetProvider>().To<ResourcesAssetProvider>().AsSingle().NonLazy();
            Container.Bind<ISaverLoader>().To<PrefsSaverLoader>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InitDataSOLoader>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameConfigSOLoader>().AsSingle().NonLazy();
            Container.Bind<AllDataContainer>().AsSingle();
            Container.BindInterfacesAndSelfTo<AudioPlayer>().AsSingle().NonLazy();
        }
    }
}