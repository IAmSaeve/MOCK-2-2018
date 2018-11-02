using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTService.Model;
using System.Collections.Generic;

namespace RESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoinController : ControllerBase
    {
        private static List<Coin> coinList = new List<Coin>()
        {
            new Coin(0, "Gold DK 1640", 2500, "Mike"),
            new Coin(1, "Gold NL 1764", 5000, "Anbo"),
            new Coin(2, "Gold FR1644", 35000, "Hammer"),
            new Coin(3, "Gold FR 1644", 0, "Auction"),
            new Coin(4, "Silver GR 333", 2500, "Mike")
        };

        // GET api/Coin
        [HttpGet]
        public ActionResult<List<Coin>> GetCoins()
        {
            return coinList;
        }

        // GET api/Coin/5
        [HttpGet("{id}")]
        public ActionResult<Coin> GetOneCoin(int id)
        {
            return coinList.Find((c) => c.Id == id);
        }

        // POST api/Coin
        [HttpPost]
        public void AddCoin([FromBody] Coin coin)
        {
            coinList.Add(coin);
        }

        // PUT api/Coin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/Coin/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
