using Services.GlobalState;
using Services.Http;
using Services.LocationAccess;
using Services.MapsAccess;
using Services.TimerEvents;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hitchhiker_V1.ViewModels
{
    public class MapsViewModel : INotifyPropertyChanged
    {
        public string Title { get; }

        private string infoText;
        public string InfoText
        {
            get => infoText;
            private set
            {
                if (value == infoText) return;

                infoText = value;
                var changedArgs = new PropertyChangedEventArgs(nameof(InfoText));
                PropertyChanged?.Invoke(this, changedArgs);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //locationaccess
        //timerevents
        //http

        private readonly IMapsManager _mapsManager;
        private readonly CustomState _state;
        private readonly IIntervallEventHandler _ticker;

        public MapsViewModel()
        {
            _mapsManager = DependencyService.Get<IMapsManager>();

            _state = DependencyService.Get<CustomState>();
            _state.PropertyChanged += SetInfoText;

            _ticker = DependencyService.Get<IIntervallEventHandler>();
            _ticker.Tick += OnTimerTick;
            _ticker.Tick += _mapsManager.OnTick;
            _ticker.LaunchTimerEvents();

            Console.Write(_mapsManager);

            Title = "Map";
            InfoText = "initial text";
        }

        // private void timerEventHandler()
        // private void makeGetRequest()
        // private void updateMap()

        private void SetInfoText(object o, EventArgs args)
        {
            if (_state.LocationVisible)
            {
                InfoText = "You are visible to others";
            }
            else
            {
                InfoText = "Go to 'Actions' to become visible to others";
            }
        }

        private void OnTimerTick(object o, EventArgs args)
        {
            Console.WriteLine("Ticking!!");
        }
    }
}