using Game.Root.Data;
using System;
namespace Game.MainMenu.LevelSelectionPanel
{
    public interface ILevelInputView
    {
        public void LockedInit(int LevelNumber);
        public void Init(LevelProgress levelProgress, Action inputSubscriber);
    }
}
