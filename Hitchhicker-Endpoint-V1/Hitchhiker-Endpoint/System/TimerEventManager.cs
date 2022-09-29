using Hitchhicker_Endpoint.Services.HitchhikerManager;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Hitchhicker_Endpoint_V1.System
{
    public class TimerEventManager
    {
        private readonly Timer _timer;
        private readonly IHitchhikerManager _hitchhikerManager;

        public TimerEventManager(int intervalInSeconds, IHitchhikerManager hitchhikerManager)
        {
            _timer = new Timer(intervalInSeconds*1000);
            _hitchhikerManager = hitchhikerManager;
        }

        public void LaunchTimerEvents()
        {
            // subscribe Methods to be fired at timer intervals
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;

            Console.WriteLine("\nPress the Enter key to stop the timer intervals...\n");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            _timer.Stop();
            _timer.Dispose();

            Console.WriteLine("Intervals stopped.");
        }

        private void OnTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            _hitchhikerManager.DeleteAllExpired();
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                                e?.SignalTime);
        }
    }
}