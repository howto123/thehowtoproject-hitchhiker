using Hitchhiker_V1.Views;
using Xamarin.Forms;

namespace Hitchhiker_V1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DisplayPage), typeof(DisplayPage));
            Routing.RegisterRoute(nameof(ActionsPage), typeof(ActionsPage));
        }
    }
}
