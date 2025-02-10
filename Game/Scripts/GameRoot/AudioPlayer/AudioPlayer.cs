using Game.Root.Data;
using R3;
using UnityEngine;
namespace Game.Root.Audio
{
    class AudioPlayer : IAudioPlayer<AudioClip>
    {
        readonly AudioSourcesHolder sourcesHolder;
        readonly AllDataContainer allDataContainer;
        public AudioPlayer(AudioSourcesHolder _sourcesHolder, AllDataContainer _allDataContainer)
        {
            sourcesHolder = _sourcesHolder;
            allDataContainer = _allDataContainer;
        }

        public void Init()
        {
            allDataContainer.SettingsData.MusicVolume.Subscribe(volume => sourcesHolder.BGAudioSource.volume = volume);
            allDataContainer.SettingsData.SoundsVolume.Subscribe(volume => sourcesHolder.SFXAudioSource.volume = volume);

            sourcesHolder.BGAudioSource.loop = true;
        }
        public void PlaySFX(AudioClip clip)
        {
            if(clip == null)
            {
                return;
            }
            sourcesHolder.SFXAudioSource.PlayOneShot(clip);
        }
        public void SetBGMusic(AudioClip music)
        {
            if (music == null)
            {
                return;
            }
            sourcesHolder.BGAudioSource.Stop();
            sourcesHolder.BGAudioSource.clip = music;
            sourcesHolder.BGAudioSource.Play();
        }
    }
}
