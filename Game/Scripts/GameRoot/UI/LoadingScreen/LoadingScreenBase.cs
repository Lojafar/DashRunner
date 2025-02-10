using UnityEngine;

namespace Game.Root.UI.LoadingScreen
{
    public abstract class LoadingScreenBase : MonoBehaviour
    {
        public abstract void UpdateProgress(float progress);
        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
