using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tretiy.Model;

namespace Tretiy
{
    public class JsonClass : IJson
    {
        
       
        public async Task ReadJson(string path)
        {
            string filename = Path.GetFileName(path);
            ObservableCollection<DataModel> models = await ReadAsyncData(path);
            Application.Current.Dispatcher.Invoke(() =>
            {
                switch (filename)
                {
                    case "file.json":
                        TodayViewModel.Instance.TodayData = models;
                        break;
                    case "NewJsonItems.json":
                        HistoryViewModel.Instance.PastDataElements = models;
                        break;
                    default:
                        break;
                }
            });
           
           
        }
        private async Task<ObservableCollection<DataModel>> ReadAsyncData(string path)
        {
            using (FileStream file = File.Open(path, FileMode.Open))
            {
                byte[] data2 = new byte[file.Length];
                await file.ReadAsync(data2);
                string line = Encoding.Default.GetString(data2);
                Debug.WriteLine(line);
               return JsonConvert.DeserializeObject<ObservableCollection<DataModel>>(line);
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
