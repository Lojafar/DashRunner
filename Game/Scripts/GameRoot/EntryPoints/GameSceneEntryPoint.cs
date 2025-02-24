using Zenject;
using Game.Root.EntryPoint.EntryParams;
namespace Game.Root.EntryPoint
{
    class GameSceneEntryPoint : IInitializable
    {
        public GameSceneEntryPoint()
        {
        }
        public void Initialize()
        {
            if(EntryParamHolder.CurrentEntryParam != null && EntryParamHolder.CurrentEntryParam is GameSceneEntryParam entryParam)
            {
                UnityEngine.Debug.Log(entryParam.Level);
            }
        }
    }
}
