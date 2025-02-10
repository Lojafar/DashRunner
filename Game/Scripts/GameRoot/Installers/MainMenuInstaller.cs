using Game.Root.EntryPoint;
using Game.Root.UI;
using Game.MainMenu.MenuPanel;
using Game.MainMenu.SettingsPanel;
using Game.MainMenu.LevelSelectionPanel;
using Zenject;

namespace Game.Root.Installers
{
    class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
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
        }
    }
}
