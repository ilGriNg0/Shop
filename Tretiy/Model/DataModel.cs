using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tretiy;
namespace Tretiy.Model
{
    public class DataModel : INotifyPropertyChanged
    {
        private DateTime _dateTimeItem;

        public DateTime DateTimeItem
        {
            set 
            {
                _dateTimeItem = value;
                OnPropertyChanged("DateTimeItem");
            }
            get => _dateTimeItem; 
        }
        private string _nameItem;
        public string NameItem
        {
            set
            {
                _nameItem = value;
                OnPropertyChanged("NameItem");
            }
            get => _nameItem;
        }

        private int _countItem;
        public int CountItem
        {
            set
            {
                if(value > 0)
                {
                    _countItem = value;
                    OnPropertyChanged("CountItem");
                }
            }
            get => _countItem;
        }

        private int _priceItem;
        public int PriceItem
        {
            set
            {
                if (value > 0)
                {
                    _priceItem = value;
                    OnPropertyChanged("PriceItem");
                }
            }
            get => _priceItem;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public DataModel() { DateTimeItem = DateTime.Now.Date; }
    }
}
