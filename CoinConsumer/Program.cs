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
        private static readonly string Uri = "http://easj-mock2-2018.azurewebsites.net/api/coin/";
        // private static readonly string Uri = "http://localhost:5000/api/Coin/";

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Vælg en handling, 1: GET, 2: GET one, 3: POST");
            var handling = Console.ReadLine();

            if (handling == "1")
            {
                Console.Clear();
                // Get list of Coins
                foreach (var c in GetCoinAsync().Result)
                {
                    System.Console.WriteLine(c);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[]{});
            }
            else if (handling == "2")
            {
                Console.Clear();
                System.Console.WriteLine("Indtast et id");

                var coin = Console.ReadLine();
                Console.WriteLine(GetACoinAsync(int.Parse(coin)).Result);

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[]{});
            }
            else if (handling == "3")
            {
                Console.Clear();
                System.Console.WriteLine("Indtast et id");
                var id = Console.ReadLine();

                System.Console.WriteLine("Indtast en genstand");
                var genstand = Console.ReadLine();

                System.Console.WriteLine("Indtast et bud");
                var bud = Console.ReadLine();

                System.Console.WriteLine("Indtast et navn");
                var navn = Console.ReadLine();

                PostCoinAsync(new Coin(int.Parse(id), genstand, int.Parse(bud), navn));

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[]{});
            }
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

        public static void PostCoinAsync(Coin coin)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(coin);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = client.PostAsync(Uri, content).Result;
                Console.WriteLine(response.StatusCode.ToString());
            }
        }
    }
}