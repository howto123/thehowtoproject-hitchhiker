using Hitchhiker_V1.ViewModels;
using Services.Http;
using Services.LocationAccess;
using Services.MapsAccess;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hitchhiker_V1.Views
{
    public partial class MapsPage : ContentPage
    {
        private readonly MapsViewModel _viewModel;
        public MapsPage()
        {
            InitializeComponent();

            // get dependencies to inject
            //var mapsSingleton = DependencyService.Get<IMapsManager>();

            // create viewModel
            _viewModel = new MapsViewModel(/*mapsSingleton*/);

            // bind context
            BindingContext = _viewModel;
        }

    }
}