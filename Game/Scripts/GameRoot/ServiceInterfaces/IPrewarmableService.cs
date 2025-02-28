using Cysharp.Threading.Tasks;

namespace Game.Root.ServiceInterfaces
{
    public interface IPrewarmableService
    {
        public UniTask Prewarm();
    }
}
