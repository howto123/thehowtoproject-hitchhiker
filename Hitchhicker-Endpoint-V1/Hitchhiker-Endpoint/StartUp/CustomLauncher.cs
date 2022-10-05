
using Hitchhicker_Endpoint.System;


namespace Hitchhicker_Endpoint.StartUp
{
    /// <summary>
    /// faciliates startup as multithread app
    /// </summary>
    public class CustomLauncher
    {
        private readonly TimerEventManager _timerEventManager;
        private readonly WebApplication _webApp;
        public CustomLauncher(WebApplication webApp, TimerEventManager timerEventManager)
        {
            _webApp = webApp;
            _timerEventManager = timerEventManager;
        }
        public void Launch()
        {
            Thread threadWeb = new(LaunchWebApp);
            Thread threadTimer = new(LaunchTimer);

            threadWeb.Start();
            threadTimer.Start();
        }
        private void LaunchTimer()
        {
            _timerEventManager.LaunchTimerEvents();
        }
        private void LaunchWebApp()
        {
            _webApp.Run();
        }
    }
}
