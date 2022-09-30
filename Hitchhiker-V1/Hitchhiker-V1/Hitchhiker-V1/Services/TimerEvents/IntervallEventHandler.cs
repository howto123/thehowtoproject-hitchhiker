using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Services.TimerEvents
{
    public class IntervallEventHandler : IIntervallEventHandler
    {
        private readonly Timer _timer;

        IntervallEventHandler()
        {
            _timer = new Timer();
        }

        public void LaunchTimerEvents(int intervalInSeconds)
        {
            _timer.Interval = intervalInSeconds;
            Console.WriteLine(intervalInSeconds);
        }
    }
}
