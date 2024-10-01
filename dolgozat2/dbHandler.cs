using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace dolgozat2
{
    public class pekaru
    {
        public int id { get; set; }
        public string nev { get; set; }
        public int db { get; set; }
        public int ar { get; set; }
    }
    public class dbHandler
    {
        MySqlConnection connection;
        string tableName = "pek";
        public dbHandler()
        {
            string host = "localhost";
            string user = "root";
            string password = "";
            string database = "pekseg";
            string conString = $"host={host};user={user};password={password};database={database}";
            connection = new MySqlConnection(conString);
        }
        public List<pekaru> readAll()
        {
            List<pekaru> list = new List<pekaru>();
            try
            {
                connection.Open();
                string query = $"select * from {tableName}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    pekaru one = new pekaru();
                    one.id = read.GetInt32(read.GetOrdinal("id"));
                    one.nev = read.GetString(read.GetOrdinal("nev"));
                    one.db = read.GetInt32(read.GetOrdinal("db"));
                    one.ar = read.GetInt32(read.GetOrdinal("ar"));
                    list.Add(one);
                }
                read.Close();
                command.Dispose();
                connection.Close();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return list;
            }
        }
        public void addOne(string nev, int db, int ar)
        {
            try
            {
                connection.Open();
                string query = $"insert into {tableName} (nev, db, ar) values ('{nev}',{db},{ar})";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void deletOne(int id)
        {
            try
            {
                connection.Open();
                string query = $"delete from {tableName} where id = {id}";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
