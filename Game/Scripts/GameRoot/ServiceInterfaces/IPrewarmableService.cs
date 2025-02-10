using System.Threading.Tasks;

namespace Game.Root.ServiceInterfaces
{
    public interface IPrewarmableService
    {
        public Task Prewarm();
    }
}
