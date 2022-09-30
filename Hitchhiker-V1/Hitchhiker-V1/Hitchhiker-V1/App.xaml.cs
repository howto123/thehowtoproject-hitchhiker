using Hitchhiker_V1.ViewModels;
using Services.Http;
using Services.LocalPreferences;
using Services.LocationAccess;
using Services.MapsAccess;
using Services.TimerEvents;
using Xamarin.Forms;

namespace Hitchhiker_V1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
 /*
            //Subscribing dependencies as singleton
            var http = DependencyService.Get<HttpManager>();
            DependencyService.RegisterSingleton(http);
            DependencyService.Register<IHttpManager, HttpManager>();
           
            var preferencesHandler = DependencyService.Get<PreferencesHandler>();
            DependencyService.RegisterSingleton(preferencesHandler);
            DependencyService.Register<IPreferencesHandler, PreferencesHandler>();
            
            var locationAccessor = DependencyService.Get<LocationAccessor>();
            DependencyService.RegisterSingleton(locationAccessor);
            DependencyService.Register<ILocationAccessor, LocationAccessor>();
            */
            /*
            var mapsManager = DependencyService.Get<MapsManager>();
            DependencyService.RegisterSingleton(mapsManager);
            DependencyService.Register<IMapsManager, MapsManager>();
            
            var intervallHandler = DependencyService.Get<IntervallEventHandler>();
            DependencyService.RegisterSingleton(intervallHandler);
            DependencyService.Register<IIntervallEventHandler, IntervallEventHandler>();
            
            DependencyService.Register<ActionsViewModel>();
            DependencyService.Register<MapsViewModel>();
*/
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
