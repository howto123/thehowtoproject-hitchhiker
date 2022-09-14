using Hitchhiker_V1.ViewModels;
using Hitchhiker_V1.Views;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Hitchhiker_V1.Services;

namespace Hitchhiker_V1.Views
{
    public partial class ActionsPage : ContentPage
    {
        ActionsViewModel _viewModel;

        public ActionsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ActionsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
        public async void ShowMeClicked(object sender, EventArgs args)
        {
            string message = await _viewModel.ShowMeClicked();
            await DisplayAlert("Alert", message, "Ok");
        }
        public void StoreToPreferences(object sender, EventArgs args)
        {
            DisplayAlert("Alert", $"{setKey.Text}, {setValue.Text}", "Ok");
            _viewModel.SetPreference(setKey.Text, setValue.Text);
        }
        public void GetPreference(object sender, EventArgs args)
        {
            DisplayAlert("Alert", $"{_viewModel.GetPreference(getKey.Text)}", "Ok");
        }

        public async void GetRequest(object sender, EventArgs args)
        {
            string message = await _viewModel.GetHitchhikers();
            await DisplayAlert("Alert", message, "Ok");
        }
        public void PostRequest(object sender, EventArgs args)
        {
            string message = _viewModel.PostHitchhiker(destination.Text);
            DisplayAlert("Alert", message, "Ok");
        }
    }
}