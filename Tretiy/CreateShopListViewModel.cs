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
namespace Tretiy
{
    public class CreateShopListViewModel : INotifyPropertyChanged
    {
        DataModel Model { get; set; }
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
            DataModels = new();
            DataModels.Add(new());
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

        private RelayCommand _saveDataInfoPanel;
        public RelayCommand SaveDataInfoPanel
        {
            get => _saveDataInfoPanel ?? (_saveDataInfoPanel = new RelayCommand(() =>
            {
                
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
                        DataModels.Remove(items);
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
