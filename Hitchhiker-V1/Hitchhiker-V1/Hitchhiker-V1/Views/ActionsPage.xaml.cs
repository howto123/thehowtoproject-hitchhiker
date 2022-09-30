using Hitchhiker_V1.ViewModels;
using Services.Http;
using Services.MapsAccess;
using System;
using Xamarin.Forms;

namespace Hitchhiker_V1.Views
{
    public partial class ActionsPage : ContentPage
    {
        private readonly ActionsViewModel _viewModel;

        public ActionsPage()
        {
            InitializeComponent();

            // get instances to inject
            var httpSingleton = DependencyService.Get<IHttpManager>();
            var mapsSingleton = DependencyService.Get<IMapsManager>();

            // create viewModel
            _viewModel = new ActionsViewModel(httpSingleton, mapsSingleton);

            // bind
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //_viewModel.OnAppearing();
        }
        public async void ShowMeClicked(object sender, EventArgs args)
        {
            //string message = await _viewModel.ShowMeClicked();
            await DisplayAlert("Alert", "clicked()", "Ok");
        }
        public void StoreToPreferences(object sender, EventArgs args)
        {
            /*
            DisplayAlert("Alert", $"{setKey.Text}, {setValue.Text}", "Ok");
            _viewModel.SetPreference(setKey.Text, setValue.Text);
            */
        }
        public void GetPreference(object sender, EventArgs args)
        {
            /*
            DisplayAlert("Alert", $"{_viewModel.GetPreference(getKey.Text)}", "Ok");
            */
        }

        public async void GetRequest(object sender, EventArgs args)
        {
            
            await DisplayAlert("Alert", "something", "Ok");
            
        }
        public void PostRequest(object sender, EventArgs args)
        {
            /*
            string message = _viewModel.PostHitchhiker(destination.Text);
            DisplayAlert("Alert", message, "Ok");
            */
        }
    }
}