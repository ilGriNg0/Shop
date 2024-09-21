using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tretiy.Model
{
    public class DataModel : INotifyPropertyChanged
    {
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
                if(_countItem > 0)
                {
                    _countItem = value;
                    OnPropertyChanged("CountItem");
                }
            }
            get => _countItem;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public DataModel() { }
    }
}
