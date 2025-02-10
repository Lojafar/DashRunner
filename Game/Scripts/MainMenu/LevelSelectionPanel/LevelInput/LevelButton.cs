using Game.Root.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Game.MainMenu.LevelSelectionPanel
{
    [RequireComponent(typeof(Button))]
    class LevelButton : MonoBehaviour, ILevelInputView
    {
        [SerializeField] Sprite openedImg, closedImg;
        [SerializeField] TMP_Text levelNumText;
        Button btnComponent;
        public void LockedInit(int LevelNumber)
        {
            btnComponent = GetComponent<Button>();
            btnComponent.interactable = false;
            btnComponent.image.sprite = closedImg;
            levelNumText.text = LevelNumber.ToString();
        }
        public void Init(LevelProgress levelProgress, Action inputSubscriber)
        {
            btnComponent = GetComponent<Button>();
            btnComponent.interactable = levelProgress.IsOpened;
            btnComponent.image.sprite = levelProgress.IsOpened ? openedImg : closedImg;
            levelNumText.text = levelProgress.LevelNumber.ToString();
            btnComponent.onClick.AddListener(() => inputSubscriber?.Invoke());
        }
    }
}
