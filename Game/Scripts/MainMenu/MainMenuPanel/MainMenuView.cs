using R3;
using UnityEngine;
using UnityEngine.UI;
namespace Game.MainMenu.MenuPanel
{
    class MainMenuView : MainMenuViewBase
    {
        [SerializeField] Button PlayGameBtn;
        [SerializeField] Button SettingsBtn;
        [SerializeField] Button ShopBtn;
        public override void OnBind(MainMenuVM viewModel)
        {
            base.OnBind(viewModel);
            PlayGameBtn.onClick.AddListener(() => viewModel.PlayGameInputEvent.OnNext(Unit.Default));
            SettingsBtn.onClick.AddListener(() => viewModel.SettingsInputEvent.OnNext(Unit.Default));
            ShopBtn.onClick.AddListener(() => viewModel.ShopInputEvent.OnNext(Unit.Default));
        }
    }
}
