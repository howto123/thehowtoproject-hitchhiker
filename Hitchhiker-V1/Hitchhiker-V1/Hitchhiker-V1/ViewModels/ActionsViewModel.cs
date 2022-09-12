using Hitchhiker_V1.Models;
using Hitchhiker_V1.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

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

        public void ShowMeClickedViewModel()
        {
           Console.WriteLine("ActionsViewModel: ShowMeMoreClicked!");
        }
    }
}