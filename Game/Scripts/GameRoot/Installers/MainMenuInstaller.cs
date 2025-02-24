using Game.Root.EntryPoint;
using Game.Root.UI;
using Game.MainMenu;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Game.MainMenu.ShopPanel;
using Zenject;
using UnityEngine;
namespace Game.Root.Installers
{
    class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] MainMenuInstances mainMenuInstances;
        public override void InstallBindings()
        {
            Container.Bind<MainMenuInstances>().FromInstance(mainMenuInstances);
            BindServices();
            BindViews();
        }
        void BindServices()
        {
            Container.BindInterfacesAndSelfTo<MainMenuEntryPoint>().AsSingle().NonLazy();
        }
        void BindViews()
        {
            Container.Bind<TabsHandler>().AsSingle().NonLazy();
            Container.Bind<MainMenuBinder>().AsSingle().NonLazy();
            Container.Bind<MainSettingsBinder>().AsSingle().NonLazy();
            Container.Bind<LevelSelectionBinder>().AsSingle().NonLazy();
            Container.Bind<ShopTabBinder>().AsSingle().NonLazy();
        }
    }
}
