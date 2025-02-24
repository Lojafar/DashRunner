using R3;
using UnityEngine;
using UnityEngine.UI;
namespace Game.MainMenu.ShopPanel
{
    class ShopView : ShopViewBase
    {
        [SerializeField] Button BackBtn;
        public override void OnBind(ShopVM viewModel)
        {
            base.OnBind(viewModel);
            BackBtn.onClick.AddListener(() => viewModel.BackInputEvent.OnNext(Unit.Default));
        }
    }
}
