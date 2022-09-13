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
    }
}