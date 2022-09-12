using Hitchhiker_V1.Models;
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
        public void ShowMeClicked(object sender, EventArgs args)
        {
            DisplayAlert("Alert", "ShowMeClicked!", "Ok");
            Debug.WriteLine("ActionsViewModel: ShowMeMoreClicked!");
            DisplayAlert("Alert", "Written...", "Ok");
            _viewModel.ShowMeClickedViewModel();
        }
    }
}