using Game.Root.Data;
using Game.Root.SaveLoad;
using Game.Root.UI;
using Game.Root.UI.Tabs;
using Game.MainMenu.MenuPanel;
using System;
using R3;
namespace Game.MainMenu.SettingsPanel
{
    public class MainSettingsModel : TabModel
    {
        public readonly ReadOnlyReactiveProperty<float> MusicVolume;
        public readonly ReadOnlyReactiveProperty<float> SoundsVolume;
        readonly TabsHandler tabsHandler;
        readonly AllDataContainer dataContainer;
        readonly ISaverLoader saverLoader;
        bool isSettingsChanged;
        public MainSettingsModel(TabsHandler _tabsHandler, AllDataContainer _dataContainer, ISaverLoader _saverLoader)
        {
            tabsHandler = _tabsHandler;
            dataContainer = _dataContainer;
            saverLoader = _saverLoader;
            MusicVolume = dataContainer.SettingsData.MusicVolume;
            SoundsVolume = dataContainer.SettingsData.SoundsVolume;
            isSettingsChanged = false;
        }
        public void SetMusicVolume(float newVolume)
        {
            dataContainer.SettingsData.MusicVolume.Value = newVolume;
            isSettingsChanged = true;
        }
        public void SetSFXVolume(float newVolume)
        {
            dataContainer.SettingsData.SoundsVolume.Value = newVolume;
            isSettingsChanged = true;
        }
        public void OnBackInput()
        {
            tabsHandler.OpenTab<MainMenuModel>();
        }
        public override void Close(Action onCompleted)
        {
            if (isSettingsChanged)
            {
                saverLoader.SaveSettings(dataContainer.SettingsData.DataOrigin);
                isSettingsChanged = false;
            }
            ClosingEvent.OnNext(onCompleted);
        }
    }
}
