using R3;

namespace Game.Root.Data
{
    public class ProgressDataProxy
    {
        public readonly ProgressData DataOrigin;
        public ProgressDataProxy(ProgressData _progressData)
        {
            DataOrigin = _progressData;
        }
    }
}
