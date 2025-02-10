using UnityEngine;
using UnityEngine.UI;
using R3;
namespace Game.MainMenu.SettingsPanel
{
    class MainSettingsView : MainSettingsViewBase
    {
        [SerializeField] Button BackBtn;
        [SerializeField] ExtendedSlider MusicSlider;
        [SerializeField] ExtendedSlider SoundsSlider;
        public override void OnBind(MainSettingsVM viewModel)
        {
            base.OnBind(viewModel);

            BackBtn.onClick.AddListener(() => viewModel.BackInputEvent.OnNext(Unit.Default));

            viewModel.MusicVolume.Subscribe(volume => MusicSlider.value = volume);
            viewModel.SFXVolume.Subscribe(volume => SoundsSlider.value = volume);
            
            MusicSlider.OnEndChanging += volume => viewModel.MusicVolume.Value = volume;
            SoundsSlider.OnEndChanging += volume => viewModel.SFXVolume.Value = volume;
        }
    }
}
