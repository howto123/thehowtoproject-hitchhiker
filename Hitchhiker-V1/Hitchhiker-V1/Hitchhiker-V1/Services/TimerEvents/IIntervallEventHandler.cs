using System.Timers;

namespace Services.TimerEvents
{
    /// <summary>
    /// this interface launches a timer and fires the Tick event, methods (signature matters: void NAME (object x, EventArgs y) can subscribe.
    /// </summary>
    public interface IIntervallEventHandler
    {
        void LaunchTimerEvents();

        event ElapsedEventHandler Tick;
    }
}