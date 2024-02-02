using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datalayer
{
    public class Calculation
    {
        public int Id { get; set; }
        public string Results { get; set; }

    }

    public class DataLayerClass
    {

        

        private MySqlConnection connection;
        private MySqlCommand command;

        public DataLayerClass()
        {
            connection = new MySqlConnection("server=localhost;uid=root;password='';database=Labex5");
        }

        public void OpenCloseDatabase()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                connection.Close();
            }
        }

        public List<Calculation> GetAllCalculations()
        {
            List<Calculation> computes = new List<Calculation>();

            OpenCloseDatabase();
             
            MySqlCommand command = new MySqlCommand("SELECT * FROM calculations ORDER BY id ASC", connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Calculation compute = new Calculation();
                compute.Id = reader.GetInt32("id");
                compute.Results = reader.GetString("results");
                

                computes.Add(compute);
            }

            reader.Close();
            OpenCloseDatabase();

            return computes;
        }

        public bool Results (Calculation compute)
        {
            string sql = $"INSERT INTO calculations (results) VALUES ('{compute.Results}')";
            OpenCloseDatabase();
            command = new MySqlCommand(sql, connection);
            int result = command.ExecuteNonQuery();
            OpenCloseDatabase();
            return result > 0;
        }

        public class Calculation : Datalayer.Calculation
        {
            public new string Results { get; set; }
        }
    }
}
