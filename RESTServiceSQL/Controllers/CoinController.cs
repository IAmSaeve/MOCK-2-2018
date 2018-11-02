using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using RESTServiceSQL.Model;
using MySqlConnector;
using MySql.Data.MySqlClient;

namespace SQLRestCustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private const string connection = "server=192.168.122.105; uid=root; pwd=password; database=CoinDB";
        
        // GET: api/Customers
        [HttpGet]
        public List<Coin> Get()
        {
            var result = new List<Coin>();
            var sql = "SELECT * FROM Customer";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result.Add(new Coin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
                }
            }
            return result;
        }

        // GET: api/Customers/1
        [HttpGet("{id}")]
        public Coin Get(int id)
        {
            Coin result = null;
            var sql = $"SELECT * FROM Customer WHERE id = '{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    result = new Coin(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                }
            }
            return result;
        }

        // POST api/Customers
        [HttpPost]
        public void InsertCustomer(Coin coin)
        {
            var sql = "INSERT INTO Customer (id, firstName, lastName, cYear)" +
            $"VALUES (NULL, '{coin.Genstand}', '{coin.Bud}', '{coin.Navn}')";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public void UpdateCustomer(int id, [FromBody] Coin customer)
        {
            var sql = $"UPDATE Customer SET firstName = '{customer.FirstName}', " +
            $"lastName = '{customer.LastName}', cYear = '{customer.Year}' WHERE id='{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }

        // DELETE api/Customers/5
        [HttpDelete("{id}")]
        public void DeleteCustomer(int id)
        {
            var sql = $"DELETE FROM Customer WHERE id='{id}'";
            var db = new MySqlConnection(connection);
            db.Open();

            var command = new MySqlCommand(sql, db);
            var reader = command.ExecuteReader();
        }
    }
}