namespace Game.Utils.Debugers
{ 
    interface IDebuger
    {
        public void Log(object message, LogType logType);
    }
}
