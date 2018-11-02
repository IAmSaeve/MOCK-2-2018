using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RESTServiceSQL.Model;
// using MySqlConnector;
using MySql.Data.MySqlClient;

namespace SQLRestCoinService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private const string connection = "server=192.168.122.105; uid=root; pwd=password; database=CoinDB";
        
        // GET: api/Coins
        [HttpGet]
        public List<Coin> Get()
        {
            var result = new List<Coin>();
            var sql = "SELECT * FROM Coin";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Coin(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3)));
                }
            }
            return result;
        }

        // GET: api/Coins/1
        [HttpGet("{id}")]
        public Coin Get(int id)
        {
            Coin result = null;
            var sql = $"SELECT * FROM Coin WHERE id = '{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Coin(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3));
                }
            }
            return result;
        }

        // POST api/Coins
        [HttpPost]
        public void InsertCoin(Coin coin)
        {
            var sql = "INSERT INTO Coin (Id, Genstand, Bud, Navn)" +
            $"VALUES (NULL, '{coin.Genstand}', '{coin.Bud}', '{coin.Navn}')";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }

        // PUT api/Coins/5
        [HttpPut("{id}")]
        public void UpdateCoin(int id, [FromBody] Coin coin)
        {
            var sql = $"UPDATE Coin SET Genstand = '{coin.Genstand}', " +
            $"Bud = '{coin.Bud}', Navn = '{coin.Navn}' WHERE Id='{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }

        // DELETE api/Coins/5
        [HttpDelete("{id}")]
        public void DeleteCoin(int id)
        {
            var sql = $"DELETE FROM Coin WHERE id='{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }
    }
}