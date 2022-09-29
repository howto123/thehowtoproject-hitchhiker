using Hitchhicker_Endpoint.Services.HitchhikerManager;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Hitchhicker_Endpoint.System
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
            // subscribe method to be fired at timer intervals
            _timer.Elapsed += OnTimedEventHandler;

            // settings: repeat event firing, actually fire
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void OnTimedEventHandler(Object? source, ElapsedEventArgs? e)
        {
            _hitchhikerManager.DeleteAllExpired();
            Console.WriteLine("DeleteAllExpired() at {0:HH:mm:ss.fff}", e?.SignalTime);
        }
    }
}