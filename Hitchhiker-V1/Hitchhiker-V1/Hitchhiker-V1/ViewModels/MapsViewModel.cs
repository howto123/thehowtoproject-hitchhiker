using Services.Http;
using Services.LocationAccess;
using Services.MapsAccess;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hitchhiker_V1.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        public string Text { get; set; }

        private readonly IMapsManager _mapsManager;

        public MapsViewModel(IMapsManager mapsManager)
        {
            _mapsManager = mapsManager;

            Console.Write(_mapsManager);

            //Title = "Map";
            Text = "Your location not shared. Go to 'Actions' to change status.";
        }

    }
}