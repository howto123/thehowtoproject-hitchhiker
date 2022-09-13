using Hitchhiker_V1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Hitchhiker_V1.Services;

namespace Hitchhiker_V1.ViewModels
{
    public class ActionsViewModel : BaseViewModel
    {
        public ActionsViewModel()
        {
            Title = "Actions";
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public async Task<string> ShowMeClicked()
        {
            LocationAccesser locationAccesser = await LocationAccesser.CreateAsync();
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
    }
}