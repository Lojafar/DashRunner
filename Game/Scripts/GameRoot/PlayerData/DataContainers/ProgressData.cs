using System;
using System.Collections.Generic;
namespace Game.Root.Data
{
    [Serializable]
    public class ProgressData
    {
        public LevelProgress[] LevelsProgresses;
    }
    [Serializable]
    public class LevelProgress
    {
       public int LevelNumber;
       public bool IsOpened;
    }
}