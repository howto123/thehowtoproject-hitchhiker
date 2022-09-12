using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hitchhiker_V1.Views
{
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("button clicked yeah!");
            DisplayAlert("Alert", "You have been alerted", "OK");
        }
    }
}