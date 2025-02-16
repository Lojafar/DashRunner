using Game.Utils.Debugers;
namespace Game.Utils
{
    public static class DebugUtil
    {
        readonly static IDebuger debuger = new UnityDebuger();
        public static void Log(object message, LogType logType = LogType.Message)
        {
            debuger.Log(message, logType);
        }
    }
}
