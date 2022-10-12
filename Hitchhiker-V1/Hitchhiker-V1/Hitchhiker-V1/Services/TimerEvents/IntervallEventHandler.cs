using System;
using System.Timers;

namespace Services.TimerEvents
{
    public class IntervallEventHandler : IIntervallEventHandler
    {
        private readonly Timer _timer;

        public event ElapsedEventHandler Tick;
        public IntervallEventHandler()
        {
            try
            {
                var interval = int.Parse(Environment.GetEnvironmentVariable("timerInterval"));
                _timer = new Timer
                {
                    // Interval takes milliseconds
                    Interval = interval * 1000,
                    AutoReset = true,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LaunchTimerEvents()
        {
            // subscribe method to be called when the timer event gets fired
            _timer.Elapsed += OnElapsed;
            _timer.Enabled = true;
        }

        private void OnElapsed(object o, ElapsedEventArgs args)
        {
            // fire the public event
            Tick?.Invoke(0, args);
        }
    }
}
