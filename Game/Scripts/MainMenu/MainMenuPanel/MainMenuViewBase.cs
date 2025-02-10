using Game.Root.UI.Tabs;
using R3;

namespace Game.MainMenu.MenuPanel
{
    public abstract class MainMenuViewBase : TabViewBase<MainMenuVM>
    {
        public override void OnBind(MainMenuVM viewModel)
        {
            viewModel.OpeningEvent.Subscribe(onCompleted => Open(onCompleted));
            viewModel.ClosingEvent.Subscribe(onCompleted => Close(onCompleted));
        }
    }
}
