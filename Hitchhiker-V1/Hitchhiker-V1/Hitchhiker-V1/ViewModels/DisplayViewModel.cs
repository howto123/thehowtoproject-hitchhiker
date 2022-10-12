using Hitchhiker_V1.Models;
using Services.Http;
using Services.MapsAccess;
using Services.TimerEvents;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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

        private readonly IIntervallEventHandler _ticker;
        private readonly IHttpManager _httpManager;

        public DisplayViewModel()
        {
            _ticker = DependencyService.Get<IIntervallEventHandler>();
            _ticker.Tick += OnTimerTick;
            _ticker.LaunchTimerEvents();

            _httpManager = DependencyService.Get<IHttpManager>();

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