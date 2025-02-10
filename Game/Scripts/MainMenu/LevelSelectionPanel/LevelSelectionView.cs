using Game.Root.Data;
using R3;
using UnityEngine;
using UnityEngine.UI;
namespace Game.MainMenu.LevelSelectionPanel
{
    class LevelSelectionView : LevelSelectionViewBase
    {
        [SerializeField] Button backBtn;
        [SerializeField] Transform levelsContainer;
        [SerializeField] LevelButton levelBtnPrefab;
        ILevelInputView[] spawnedLevelsBtns;
        public override void OnBind(LevelSelectionVM viewModel)
        {
            base.OnBind(viewModel);
            backBtn.onClick.AddListener(() => viewModel.BackInputEvent.OnNext(Unit.Default));
            viewModel.OnCreateLevels.Subscribe(levelsCount => CreateLevelsGrid(levelsCount));
            viewModel.OnLevelInit.Subscribe(levelProgress => InitUnlockedLevelBtn(levelProgress));
        }
        void CreateLevelsGrid(int levelsCount)
        {
            spawnedLevelsBtns = new ILevelInputView[levelsCount];
            for(int i = 0; i < levelsCount; i++)
            {
                ILevelInputView levelButton = Instantiate(levelBtnPrefab, levelsContainer);
                levelButton.LockedInit(i + 1);
                spawnedLevelsBtns[i] = levelButton;
            }
            viewModel.OnAllLevelsSpawned();
        }
        void InitUnlockedLevelBtn(LevelProgress levelProgress)
        {
            if (spawnedLevelsBtns.Length > levelProgress.LevelNumber)
            {
                spawnedLevelsBtns[levelProgress.LevelNumber - 1].Init(levelProgress, () => OnLevelInput(levelProgress.LevelNumber));
            }
        }
        void OnLevelInput(int lvlNumber)
        {
            viewModel.LevelInputEvent.OnNext(lvlNumber);
        }
    }
}
