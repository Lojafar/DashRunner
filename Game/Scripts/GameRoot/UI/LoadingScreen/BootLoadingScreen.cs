using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
namespace Game.Root.UI.LoadingScreen
{
    public class BootLoadingScreen : LoadingScreenBase
    {
        [SerializeField] Image progressBar;
        [SerializeField] TMP_Text percentsTMP;
        const float fillAnimSpeed = 0.1f;
        private void Awake()
        {
            progressBar.fillAmount = 0;
        }
        public override void UpdateProgress(float progress)
        {
            progressBar.DOFillAmount(progress, fillAnimSpeed);
            percentsTMP.text = ((int)(progress * 100)).ToString() + "%";
        }

    }
}
