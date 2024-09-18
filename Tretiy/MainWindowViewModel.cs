using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.Input;
namespace Tretiy
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        ICommands commands;
        private RelayCommand _openTodayView;

        public RelayCommand OpenTodayView
        {
            get => _openTodayView ?? (_openTodayView ??= new RelayCommand( () =>
            {
                commands.OpenTodayView();
            })); 
        }
      
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        private RelayCommand _openHistoryView;

        public RelayCommand OpenHistoryView
        {
            get => _openHistoryView ?? (_openHistoryView ??= new RelayCommand(() => { commands.OpenHistoryView(); }));                  
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public MainWindowViewModel(ICommands commands)
        {
            this.commands = commands;
            CurrentView = new HistoryView();
        }
        
        private static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MainWindowViewModel(new Commands());  
                }   

                return _instance;
            }
        }
       
    }
}
