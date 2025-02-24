using Game.Root.UI.Tabs;
using R3;

namespace Game.MainMenu.ShopPanel
{
    public abstract class ShopViewBase : TabViewBase<ShopVM>
    {
        public override void OnBind(ShopVM viewModel)
        {
            viewModel.OpeningEvent.Subscribe(onCompleted => Open(onCompleted));
            viewModel.ClosingEvent.Subscribe(onCompleted => Close(onCompleted));
        }
    }
}
