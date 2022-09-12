using Hitchhiker_V1.ViewModels;
using Hitchhiker_V1.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Hitchhiker_V1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MapsPage), typeof(MapsPage));
            Routing.RegisterRoute(nameof(ActionsPage), typeof(ActionsPage));
        }

    }
}
