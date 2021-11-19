
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TravelMate.Services;


namespace TravelMate.ViewModels
{
    public class FuelStationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<FuelStation> station;

        /*
        public ObservableCollection<FuelStation> Station;
        {
            get { return = station; }
            set { station = value; }
        }

        public FuelStationModel()
        {

        }
        */
    }
       
}
