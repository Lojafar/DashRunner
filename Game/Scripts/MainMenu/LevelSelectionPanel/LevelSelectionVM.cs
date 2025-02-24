using Game.Root.Data;
using System;
using R3;

namespace Game.MainMenu.LevelSelectionPanel
{
    public class LevelSelectionVM
    {
        readonly LevelSelectionModel model;
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public readonly Subject<Unit> BackInputEvent;
        public readonly Subject<int> OnCreateLevels;
        public readonly Subject<LevelProgress> OnLevelInit;
        public readonly Subject<int> LevelInputEvent;
        readonly CompositeDisposable subscriptions;
        public LevelSelectionVM(LevelSelectionModel _model)
        {
            model = _model;
            OpeningEvent = model.OpeningEvent;
            ClosingEvent = model.ClosingEvent;
            OnCreateLevels = model.CreateLevelsEvent;
            OnLevelInit = model.LevelInitEvent;
            BackInputEvent = new Subject<Unit>();
            LevelInputEvent = new Subject<int>();
            subscriptions = new CompositeDisposable();
        }
        public void Init()
        {
            BackInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(_ => model.OnBackInput()).AddTo(subscriptions);
            LevelInputEvent.ThrottleFirst(TimeSpan.FromSeconds(0.3f)).Subscribe(lvlNum => model.OnLevelInput(lvlNum)).AddTo(subscriptions);
        }
        public void OnAllLevelsSpawned()
        {
            model.InitSavedLevels();
        }
    }
}
