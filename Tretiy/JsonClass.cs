using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tretiy.Model;

namespace Tretiy
{
    public class JsonClass : IJson
    {
        private string path = "C:\\Users\\User\\source\\repos\\Tretiy\\Tretiy\\Components\\file.json";
       
        public async void ReadJson()
        {
            
            using(FileStream file = File.Open(path, FileMode.Open))
            {
                byte[] data = new byte[file.Length];
                await file.ReadAsync(data);
                string line = Encoding.Default.GetString(data);
                Debug.WriteLine(line);
                ObservableCollection<DataModel> data_ = JsonConvert.DeserializeObject<ObservableCollection<DataModel>>(line);

                if (data_ != null)
                {
                    TodayViewModel.Instance.TodayData = data_;
                }
            }
        }

        public async void WriteJson(ObservableCollection<DataModel> data)
        {
            using (FileStream file = new FileStream("NewJsonItems.json", FileMode.OpenOrCreate))
            {
                string jsonData = JsonConvert.SerializeObject(data);
                byte[] masStr = Encoding.Default.GetBytes(jsonData);
                await file.WriteAsync(masStr);
            }
        }
    }
}
