using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Hitchhiker_V1.Models;
using Services.Http;
using Services.LocalPreferences;
using Services.MapsAccess;
using Services.LocationAccess;

namespace Hitchhiker_V1.ViewModels
{
    public class ActionsViewModel : BaseViewModel
    {
        //private readonly IHttpManager _httpManager;
        //private IMapsManager _mapsManager;
        public ActionsViewModel(/*IHttpManager http , IMapsManager maps*/)
        {
            Title = "Actions";
            //_httpManager = http;
            //_mapsManager = maps;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async Task<string> ShowMeClicked()
        {
            LocationAccessor locationAccesser = await LocationAccessor.CreateAsync();
            Location location = locationAccesser.GetLocation();
            return $"Location is: {location.Latitude}, {location.Longitude}";
        }


        public string SetPreference(string key, string value)
        {
            PreferencesHandler preferencesHandler = PreferencesHandler.GetInstance();
            preferencesHandler.SetPreference(key, value);
            return "Preference set successfully!";
        }
        public string GetPreference(string key)
        {
            PreferencesHandler preferencesHandler = PreferencesHandler.GetInstance();
            return preferencesHandler.GetPreference(key);
        }

        public async Task<string> GetHitchhikers()
        {
            HttpManager manager = HttpManager.GetInstance();
            return (await manager.GetAllHitchhikers()).ToString();
        }

        public string PostHitchhiker(string destination)
        {
            HttpManager manager = HttpManager.GetInstance();
            Hitchhiker hitchhiker = new Hitchhiker();
            Console.WriteLine("hitchhiker: ");
            Console.WriteLine(hitchhiker);
            hitchhiker.Location = new Location(13.4, -12.78);
            hitchhiker.Destination = destination;
            return manager.AddHitchhiker(hitchhiker).ToString();
        }
    }
}