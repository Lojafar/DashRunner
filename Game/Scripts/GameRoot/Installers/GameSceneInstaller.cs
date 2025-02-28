using Game.Root.EntryPoint;
using Game.Gameplay.Player;
using Game.Gameplay.Player.Input;
using Game.Gameplay.Player.Movement;
using Game.Gameplay.Player.Animation;
using Game.Gameplay.Player.Camera;
using UnityEngine;
using Zenject;

namespace Game.Root.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [SerializeField] Player playerInstance;
        [SerializeField] VisualAnimator visualAnimInstance;
        [SerializeField] CameraFollower camFollowerInstance;
        public override void InstallBindings()
        {
            BindServices();
        }
        void BindServices()
        {
            Container.BindInterfacesAndSelfTo<Player>().FromInstance(playerInstance);
            Container.Bind<IVisualAnimator>().FromInstance(visualAnimInstance);
            Container.Bind<ICameraFollower>().FromInstance(camFollowerInstance);
            Container.BindInterfacesAndSelfTo<GameSceneEntryPoint>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PCGameInput>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DefaultPlayerMovable>().AsSingle().NonLazy();
        }
    }
}
