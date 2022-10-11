using Hitchhiker_V1.ViewModels;
using Services.GlobalState;
using Services.Http;
using Services.LocalPreferences;
using Services.LocationAccess;
using Services.MapsAccess;
using Services.TimerEvents;
using System;
using Xamarin.Forms;

namespace Hitchhiker_V1
{
    public partial class App : Application
    {

        public App()
        {
            const string URI = "http://localhost";
            Environment.SetEnvironmentVariable("hitchhikerUri", URI);

            const int INTERVAL_IN_SECONDS = 2;
            Environment.SetEnvironmentVariable("timerInterval", INTERVAL_IN_SECONDS.ToString());


            InitializeComponent();

            
            //Subscribing dependencies as singleton
            var httpManager = new HttpManager(null, null);
            DependencyService.RegisterSingleton(httpManager);
            DependencyService.Register<IHttpManager, HttpManager>();
            
            var preferencesHandler = DependencyService.Get<PreferencesHandler>();
            DependencyService.RegisterSingleton(preferencesHandler);
            DependencyService.Register<IPreferencesHandler, PreferencesHandler>();
              
            var locationAccessor = DependencyService.Get<LocationAccessor>();
            DependencyService.RegisterSingleton(locationAccessor);
            DependencyService.Register<ILocationAccessor, LocationAccessor>();
          
            var mapsManager = new MapsManager();
            DependencyService.RegisterSingleton(mapsManager);
            DependencyService.Register<IMapsManager, MapsManager>();

            var state = new CustomState();
            DependencyService.RegisterSingleton<CustomState>(state);

            var intervallHandler = new IntervallEventHandler();
            DependencyService.RegisterSingleton(intervallHandler);
            DependencyService.Register<IIntervallEventHandler, IntervallEventHandler>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
