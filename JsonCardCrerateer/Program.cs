using Newtonsoft.Json;
using System.Text;

namespace JsonCardCrerateer
{
    internal class Program
    {
        public class JsonCard
        {
            public string NameItem { get; set; }
            public int PriceItem { get; set; }
            public DateTime DateTimeItem { get; set; }
            public int CountItem { get; set; }  

            public JsonCard(string name, int price, DateTime time, int count)
            {
                NameItem = name;
                PriceItem = price;  
                DateTimeItem = time;
                CountItem = count;
            }   
            public JsonCard() { }
        }
         static async Task Main(string[] args)
        {
            JsonCard jsonCard = new();
            List<JsonCard> jsonCards = new List<JsonCard>();
            jsonCards.Add(new JsonCard { CountItem = 12, DateTimeItem = new DateTime(2024, 7, 10), NameItem = "Мясо", PriceItem = 1000});
            jsonCards.Add(new JsonCard { CountItem = 1, DateTimeItem = new DateTime(2024, 8, 23), NameItem = "Мясо", PriceItem = 1000 });
            jsonCards.Add(new JsonCard { CountItem = 2, DateTimeItem = new DateTime(2024, 9, 22), NameItem = "Мясо", PriceItem = 1000 });
            jsonCards.Add(new JsonCard { CountItem = 34, DateTimeItem = new DateTime(2024, 9, 22), NameItem = "Масло", PriceItem = 100 });
            jsonCards.Add(new JsonCard { CountItem = 20, DateTimeItem = new DateTime(2024, 9, 22), NameItem = "Рыба", PriceItem = 1200 });
            using (FileStream file = new FileStream("file.json", FileMode.OpenOrCreate))
            {
                //foreach (var item in jsonCards)
                //{
                    string str = JsonConvert.SerializeObject(jsonCards);
                    byte[] mas = Encoding.Default.GetBytes(str);
                    await file.WriteAsync(mas);
                //}
            }

            using (FileStream file = File.OpenRead("file.json"))
            {
                byte[] bt = new byte[file.Length];
                await file.ReadAsync(bt);
                string text = Encoding.Default.GetString(bt); 
                Console.WriteLine(text);
            }
          
        }
    }
}
