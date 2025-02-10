using UnityEngine;
namespace Game.Root.Audio
{
    class AudioSourcesHolder : MonoBehaviour
    {
       [field: SerializeField] public AudioSource BGAudioSource { get; private set; }  
       [field: SerializeField] public AudioSource SFXAudioSource { get; private set; }  
    }
}
