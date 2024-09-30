using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tretiy.Model;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation;
using System.DirectoryServices;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
namespace Tretiy
{
    public class CreateShopListViewModel : INotifyPropertyChanged
    {
        DataModel Model { get; set; }

        JsonClass JsonClass { get; set; }

        private bool _isFocusedTextBox;

        public bool IsFocusedTextBox
        {
            set
            {
                _isFocusedTextBox = value;
                OnPropertyChanged("IsFocusedTextBox");
            }
            get => _isFocusedTextBox;
        }

        private ObservableCollection<DataModel> _dataModels;
        public ObservableCollection<DataModel> DataModels
        {
            set
            {
               
                _dataModels = value;
                OnPropertyChanged("DataModels");
            }

            get { return _dataModels; }
        }
        public CreateShopListViewModel()
        {
            Model ??= new();
            JsonClass ??= new();
            DataModels = new();
            DataModels.Add(new());
        }
        private static CreateShopListViewModel _instance;
        public static CreateShopListViewModel Instance
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new CreateShopListViewModel();
                }
                return _instance;
            }
        }
        private RelayCommand<string> _focusTextBox;
        public RelayCommand<string> FocusTextBox
        {
            get
            {
                return _focusTextBox ?? (_focusTextBox ??= new RelayCommand<string>(obj =>
                {
                    if (obj is string create && !string.IsNullOrWhiteSpace(create))
                    {
                        IsFocusedTextBox = true;
                    }
                    else
                    {
                        IsFocusedTextBox= false;
                    }
                }));
            }
        }
        private RelayCommand<object> _addNewItemInfoPanel;

        public RelayCommand<object> AddNewItemInfoPanel
        {
            get { return _addNewItemInfoPanel ?? (_addNewItemInfoPanel ??= new RelayCommand<object>((obj) =>
            
            {
                if (obj is DataModel data && Validation(data))
                {                   
                    DataModels.Add(new DataModel());
                }
 
            })); }
        }

        private RelayCommand<object> _saveDataInfoPanel;
        public RelayCommand<object> SaveDataInfoPanel
        {
            get => _saveDataInfoPanel ?? (_saveDataInfoPanel = new RelayCommand<object>((param) =>
            {
                if(param is CreateShopListViewModel createShopListViewModel && createShopListViewModel.DataModels.All(p => p.NameItem != string.Empty && p.CountItem != 0))
                {
                    var item = createShopListViewModel.DataModels; 
                    
                    JsonClass.WriteJson(item);
                }
              
            }));
        }

        private RelayCommand<object> _deleteDataInfoPanel;

        public RelayCommand<object> DeleteDataInfoPanel
        {
            get { return _deleteDataInfoPanel ?? (_deleteDataInfoPanel ??= new RelayCommand<object>((obj) =>
            {
                if(obj is DataModel data)
                {
                    var item = DataModels.IndexOf(data);
                    foreach (var items in DataModels.Skip(item))
                    {
                        if(DataModels.Count > 1)
                        {
                            DataModels.Remove(items);
                            break;
                        }
                       
                    }
                }
            })); }
        }

        private bool Validation(DataModel data) => string.IsNullOrWhiteSpace(data?.NameItem) ? false : true;
       
       
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
