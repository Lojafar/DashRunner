using R3;
using System.Collections.Generic;
namespace Game.Root.Data
{
    public class ProgressDataProxy
    {
        public readonly ProgressData DataOrigin;
        public readonly HashSet<LevelProgress> levels;
        public ProgressDataProxy(ProgressData _progressData)
        {
            DataOrigin = _progressData;
            levels = new HashSet<LevelProgress>(DataOrigin.LevelsProgresses);
        }
        public void Init()
        {

        }
    }
}
