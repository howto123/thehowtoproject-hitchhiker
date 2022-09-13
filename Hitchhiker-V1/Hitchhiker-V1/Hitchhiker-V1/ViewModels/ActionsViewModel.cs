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
    }
}