using Hitchhiker_V1.Models;
using Services.GlobalState;
using Services.Http;
using Services.LocationAccess;
using Services.MapsAccess;
using Services.TimerEvents;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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

        private readonly IMapsManager _mapsManager;
        private readonly CustomState _state;
        private readonly IIntervallEventHandler _ticker;
        private readonly IHttpManager _httpManager;

        public MapsViewModel()
        {
            _mapsManager = DependencyService.Get<IMapsManager>();

            _state = DependencyService.Get<CustomState>();
            _state.PropertyChanged += SetInfoText;

            _ticker = DependencyService.Get<IIntervallEventHandler>();
            _ticker.Tick += OnTimerTick;
            _ticker.LaunchTimerEvents();

            _httpManager = DependencyService.Get<IHttpManager>();

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
            Act();
            Console.WriteLine("Ticking!!");
        }

        private async Task Act()
        {
            var hitchhikers = await _httpManager.GetAllHitchhikers();

            hitchhikers.ForEach(h =>
            {
                Console.WriteLine(HitchhikerAsString(h));
            });
        }

        private string HitchhikerAsString(Hitchhiker h)
        {
            return $"We have: {h.Location}, goes to {h.Destination}";
        }
    }
}