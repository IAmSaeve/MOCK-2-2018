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
        // private static readonly string CustomersUri = "";
        private static readonly string Uri = "http://localhost:5000/api/Coin/";

        static void Main(string[] args)
        {
            // Get list of Coins
            foreach (var c in GetCoinAsync().Result)
            {
                System.Console.WriteLine("ID: " + c.Id + " Genstand: " + c.Genstand + " Bud: " + c.Bud + " Navn: " + c.Navn);
            }

            Console.WriteLine(GetACoinAsync(3).Result);
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
    }
}