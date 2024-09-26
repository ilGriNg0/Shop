using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tretiy.Model;

namespace Tretiy
{
    public interface IJson
    {
        public void WriteJson(ObservableCollection<DataModel> data);
        public Task  ReadJson(string path);
    }
}
