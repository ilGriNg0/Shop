using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tretiy
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler? PropertyChanged;

        private static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MainWindowViewModel();  
                }   

                return _instance;
            }
        }
    }
}
