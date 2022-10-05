using System.Timers;

namespace Services.TimerEvents
{
    public interface IIntervallEventHandler
    {
        void LaunchTimerEvents();

        event ElapsedEventHandler Tick;
    }
}