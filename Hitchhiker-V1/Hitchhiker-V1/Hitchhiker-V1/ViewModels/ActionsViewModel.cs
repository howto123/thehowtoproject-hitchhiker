using System;
using System.Windows.Input;
using Hitchhiker_V1.Models;
using Services.Http;
using Services.LocationAccess;
using Xamarin.Forms;
using System.ComponentModel;
using Services.LocalPreferences;
using Services.GlobalState;

namespace Hitchhiker_V1.ViewModels
{
    public class ActionsViewModel : INotifyPropertyChanged
    {
        public string Title { get; private set; }
        public string DestinationEntry { get; set; }
        public string DurationEntry { get; set; }

        public bool SaveDestination { get; set; }


        public ICommand SubmitClicked { get; private set; }
        public ICommand ChangeSaveLocation { get; private set; }

        private readonly IHttpManager _httpManager;
        private readonly ILocationAccessor _locationAccessor;
        private readonly IPreferencesHandler _preferencesHandler;
        private readonly CustomState _state;

        public event PropertyChangedEventHandler PropertyChanged;

        public ActionsViewModel()
        {
            _httpManager = DependencyService.Get<IHttpManager>();
            _locationAccessor = DependencyService.Get<ILocationAccessor>();
            _preferencesHandler = DependencyService.Get<IPreferencesHandler>();
            _state = DependencyService.Get<CustomState>();

            Title = "Actions";
            DestinationEntry = LoadDestinationOrEmptyString();
            DurationEntry = "";
            SaveDestination = false;

            SubmitClicked = new Command(HandleSubmitClicked);
            ChangeSaveLocation = new Command(HandleChangeSaveLocation);
        }

        private void HandleSubmitClicked()
        {
            PostHitchhiker();

            if (SaveDestination && DestinationEntry!="")
            {
                StoreDestination();
            }

            Console.WriteLine($"LocationVisible: {_state.LocationVisible}");
            _state.LocationVisible = true;
            Console.WriteLine($"LocationVisible: {_state.LocationVisible}");
        }

        private async void PostHitchhiker()
        {
            try
            {
                var location = await _locationAccessor.GetLocation();
                var hitchhiker = new Hitchhiker()
                {
                    Location = location,
                    Destination = DestinationEntry
                };
                _httpManager.AddHitchhiker(hitchhiker);
            }
            catch (Exception e)
            {
                HandleException("postHitchhiker", e);
            }
        }

        private void StoreDestination()
        {
            _preferencesHandler.SetPreference("Destination", DestinationEntry);
            Console.WriteLine("save destination called");
        }

        private string LoadDestinationOrEmptyString()
        {
            return _preferencesHandler.GetPreference("Destination")??"";
        }

        private void HandleChangeSaveLocation()
        {
            SaveDestination = !SaveDestination;

            var changedArgs = new PropertyChangedEventArgs(nameof(SaveDestination));
            PropertyChanged.Invoke(this, changedArgs);
        }

        private void HandleException(string origin, Exception e)
        {
            Console.WriteLine($"Exception in {origin} {e.Message}");
        }
    }
}