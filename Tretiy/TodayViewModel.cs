using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tretiy.Model;

namespace Tretiy
{
    public class TodayViewModel : INotifyPropertyChanged
    {
        
        private ObservableCollection<DataModel> _todayData;
        public JsonClass JsonClass { get; set; }
       

        public ObservableCollection<DataModel> TodayData
        {
            set
            {
                _todayData = value;
                OnPropertyChanged("TodayData");
            }
            get => _todayData;
        }
        public TodayViewModel()
        {
            TodayData ??= new();
            JsonClass ??= new();
            JsonClass.ReadJson();
        }
        private static TodayViewModel _instance;
        public static TodayViewModel Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new TodayViewModel();
                }
                return _instance;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
