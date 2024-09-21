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
            DataModels = new();
            DataModels.Add(new());
        }
        private RelayCommand _addNewItemInfoPanel;

        public RelayCommand AddNewItemInfoPanel
        {
            get { return _addNewItemInfoPanel ?? (_addNewItemInfoPanel ??= new RelayCommand(() =>
            
            {           
                DataModels.Add(new DataModel()); 
            })); }
        }

        private RelayCommand _saveDataInfoPanel;
        public RelayCommand SaveDataInfoPanel
        {
            get => _addNewItemInfoPanel ?? (_addNewItemInfoPanel = new RelayCommand(() =>
            {
                var item  = DataModels.IndexOf(Model);
                foreach (var items in DataModels.Skip(item))
                {
                    items.NameItem = Model.NameItem;
                }
            }));
        }

       
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
