using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.IconPacks.Converter;
using Tretiy.Model;
namespace Tretiy
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        private string path = "C:/Users/User/source/repos/ilGriNg0/Shop/Tretiy/bin/Debug/net8.0-windows/NewJsonItems.json";
        JsonClass? _jsClass {  get; set; }

        private int _spentMoney;

        public int SpentMoney
        {
            set
            {
                _spentMoney = value;
                OnPropertyChanged("SpentMoney");
            }
            get => _spentMoney;
        }

        IJson json { get; set; }
        private DateTime _date;
        public DateTime Date
        {

            set { _date = value;   OnPropertyChanged("Date"); }
            get { return _date; }
        }

        private ObservableCollection<DataModel> _pastDataElements;
        public ObservableCollection<DataModel> PastDataElements
        {
            set
            {
                _pastDataElements = value;
                OnPropertyChanged("PastDataElements");
            }
            get => _pastDataElements; 
        }
        private RelayCommand<object> _dateSelected;
       
        public RelayCommand<object> DateSelectedCommand
        {
            get
            {
                return _dateSelected ?? (_dateSelected ??= new RelayCommand<object>(async(obj) =>
                {
                    
                    if(obj is DateTime data)
                    {
                      
                        await json.ReadJson(path);
                        data = CultureDate(data);      
                        var itemList = new ObservableCollection<DataModel>(PastDataElements.Where(p => p.DateTimeItem == data));
                        PastDataElements = itemList;
                        SpentMoney = 0;
                        var item2 = PastDataElements.Where(p => p.DateTimeItem == data).Sum(p => p.PriceItem);
                        SpentMoney = item2;
                                    
                    }
                }));
            }
        }

        private DateTime CultureDate(DateTime dateTime)
        {
           string format = dateTime.ToString("d") ?? string.Empty;
            if (DateTime.TryParse(format, out dateTime))
            {
                return dateTime.Date;
            }
            return  DateTime.MinValue;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public HistoryViewModel(IJson js) { Date = DateTime.Now; PastDataElements ??= new(); json = js; }

        private static HistoryViewModel? _instance;
        public static HistoryViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HistoryViewModel(new JsonClass());
                }
                return _instance;
            }
        }
    }
}
