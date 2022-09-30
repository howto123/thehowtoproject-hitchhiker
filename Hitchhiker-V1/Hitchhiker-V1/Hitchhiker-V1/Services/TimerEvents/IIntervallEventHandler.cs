namespace Services.TimerEvents
{
    public interface IIntervallEventHandler
    {
        void LaunchTimerEvents(int intervalInSeconds);
    }
}