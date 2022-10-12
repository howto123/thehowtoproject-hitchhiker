using Services.GlobalState;
using Services.Http;
using Services.LocationAccess;
using Services.MapsAccess;
using Services.TimerEvents;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hitchhiker_V1.ViewModels
{
    public class MyClass
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }

        public MyClass(string t1, string t2)
        {
            Prop1 = t1; Prop2 = t2; 
        }

        public override string ToString()
        {
            return $"Prop 1: {Prop1}, Prop2: {Prop2}";
        }
    }

    public class DisplayViewModel : INotifyPropertyChanged
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

        public ObservableCollection<MyClass> MyList { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        //locationaccess
        //timerevents
        //http

        private readonly IMapsManager _mapsManager;
        private readonly CustomState _state;
        private readonly IIntervallEventHandler _ticker;

        public DisplayViewModel()
        {
            _mapsManager = DependencyService.Get<IMapsManager>();

            _state = DependencyService.Get<CustomState>();
            _state.PropertyChanged += SetInfoText;

            _ticker = DependencyService.Get<IIntervallEventHandler>();
            _ticker.Tick += OnTimerTick;
            _ticker.LaunchTimerEvents();

            Console.Write(_mapsManager);

            Title = "Map";
            InfoText = "initial text";

            MyList = new ObservableCollection<MyClass>
            {
                new MyClass("hey", "you"),
                new MyClass("ach", "so ist das")
            };
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