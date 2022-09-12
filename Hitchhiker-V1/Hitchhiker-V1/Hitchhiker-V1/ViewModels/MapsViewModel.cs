using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hitchhiker_V1.ViewModels
{
    public class MapsViewModel : BaseViewModel
    {
        public string Text { get; set; }
        public MapsViewModel()
        {
            Title = "Map";
            Text = "Your location not shared. Go to 'Actions' to change status.";
        }

    }
}