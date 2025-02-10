using Game.Root.UI.Tabs;
using R3;

namespace Game.MainMenu.SettingsPanel
{
    public abstract class MainSettingsViewBase : TabViewBase<MainSettingsVM>
    {
        public override void OnBind(MainSettingsVM viewModel)
        {
            viewModel.OpeningEvent.Subscribe(onCompleted => Open(onCompleted));
            viewModel.ClosingEvent.Subscribe(onCompleted => Close(onCompleted));
        }
    }
}
