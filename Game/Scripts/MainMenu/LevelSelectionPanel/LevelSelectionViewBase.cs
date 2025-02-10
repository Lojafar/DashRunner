using Game.Root.UI.Tabs;
using R3;

namespace Game.MainMenu.LevelSelectionPanel
{
    public abstract class LevelSelectionViewBase : TabViewBase<LevelSelectionVM>
    {
        public override void OnBind(LevelSelectionVM viewModel)
        {
            viewModel.OpeningEvent.Subscribe(onCompleted => Open(onCompleted));
            viewModel.ClosingEvent.Subscribe(onCompleted => Close(onCompleted));
        }
    }
}
