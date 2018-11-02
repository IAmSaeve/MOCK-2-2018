using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoinConsumer.Model;

namespace CoinConsumer
{
    class Program
    {
        // Azure or localhost
        // private static readonly string Uri = "https://easj-mock2-2018.azurewebsites.net/api/coin/";
        private static readonly string Uri = "http://localhost:5000/api/Coin/";

        static void Main(string[] args)
        {
            // Get list of Coins
            // foreach (var c in GetCoinAsync().Result)
            // {
            //     System.Console.WriteLine("ID: " + c.Id + " Genstand: " + c.Genstand + " Bud: " + c.Bud + " Navn: " + c.Navn);
            // }

            // Console.WriteLine(GetACoinAsync(3).Result);

            PostCoinAsync(new Coin(6, "Copper DK 1500", 60, "Kevin"));
        }

        public static async Task<IList<Coin>> GetCoinAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(Uri);
                IList<Coin> coinList = JsonConvert.DeserializeObject<IList<Coin>>(content);
                return coinList;
            }
        }

        public static async Task<Coin> GetACoinAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(Uri + id);
                Coin coin = JsonConvert.DeserializeObject<Coin>(content);
                return coin;
            }
        }

        public static async Task<string> PostCoinAsync(Coin coin)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(coin);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Uri, content);
                return response.StatusCode.ToString();
            }
        }
    }
}