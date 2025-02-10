using System;
using R3;

namespace Game.Root.UI.Tabs
{
    public abstract class TabModel : ITabModel
    {
        public readonly Subject<Action> OpeningEvent;
        public readonly Subject<Action> ClosingEvent;
        public TabModel()
        {
            OpeningEvent = new Subject<Action>();
            ClosingEvent = new Subject<Action>();
        }
        public virtual void Open(Action onCompleted)
        {
            OpeningEvent.OnNext(onCompleted);
        }
        public virtual void Close(Action onCompleted)
        {
            ClosingEvent.OnNext(onCompleted);
        }
    }
}
