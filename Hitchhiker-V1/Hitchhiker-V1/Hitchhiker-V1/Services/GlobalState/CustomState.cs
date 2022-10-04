using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Services.GlobalState
{
    public class CustomState : INotifyPropertyChanged
    {
        private bool locationVisible;
        public bool LocationVisible
        {
            get => locationVisible;
            set
            {
                if(value == locationVisible) return;

                locationVisible = value;
                var changeArgs = new PropertyChangedEventArgs(nameof(LocationVisible));
                PropertyChanged?.Invoke(this, changeArgs);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomState()
        {
            LocationVisible = false;
        }
    }
}
