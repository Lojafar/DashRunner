namespace Game.Root.EntryPoint.EntryParams
{
    public class GameSceneEntryParam : IEntryParam
    {
        public readonly int Level;
        public GameSceneEntryParam(int _level)
        {
            Level = _level;
        }
    }
}
