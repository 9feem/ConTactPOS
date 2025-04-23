using ConTactPOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTactPOS.Services
{
    public class DbConnnect
    {
        private string Conn = "Data Source=DataBasePd.db; version=3;";


        public DbConnnect()
        {
            using (var Connect = new SQLiteConnection(Conn))
            {
                Connect.Open();
                String Sql = @"CREATE TABLE IF NOT EXISTS Product(id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "name TEXT," +
                    "price DECIMAL," +
                    "moreinfo TEXT )";
                var cmd = new SQLiteCommand(Sql, Connect);
                cmd.ExecuteNonQuery();
            }
        }

        public void Insertdb(Product pd)
        {
            using (var conn = new SQLiteConnection(Conn))
            {
                conn.Open();
                String sql = @"INSERT INTO Product (name,price,moreinfo)" +
                    "VALUES (@Name,@Price,@MoreInfo)";
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", pd.Name);
                cmd.Parameters.AddWithValue("@Price", pd.Price);
                cmd.Parameters.AddWithValue("@MoreInfo", pd.MoreInfo);
                cmd.ExecuteNonQuery();
            }
        }

        public ObservableCollection<Product> Selectdb()
        {
            var products = new ObservableCollection<Product>();
            using (var conn = new SQLiteConnection(Conn)) {
                conn.Open();
                string sql = @"SELECT * FROM Product ";
                var cmd = new SQLiteCommand(sql,conn);
                using (var Reader = cmd.ExecuteReader())
                {                  
                    while (Reader.Read())
                    {
                        var pd = new Product
                        {
                            Id = Reader.GetInt32(0),
                            Name = Reader.GetString(1),
                            Price = Reader.GetDecimal(2),
                            MoreInfo = Reader.GetString(3),
                        };
                        products.Add(pd);
                    }
                }
            }
            return products;
        }


        public ObservableCollection<Product> SelectdbID(Product pd)
        {
            var products = new ObservableCollection<Product>();
            using (var conn = new SQLiteConnection(Conn))
            {
                conn.Open();
                string sql = @"SELECT * FROM Product WHERE id = @id";
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",pd.Id);
                using (var Reader = cmd.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        var product = new Product
                        {
                            Id = Reader.GetInt32(0),
                            Name = Reader.GetString(1),
                            Price = Reader.GetDecimal(2),
                            MoreInfo = Reader.GetString(3),
                        };
                        products.Add(product);
                    }
                }
            }
            return products;
        }


        public void Update(Product pd)
        {
            using (var conn = new SQLiteConnection(Conn)) 
            {
                conn.Open();
                String sql = "UPDATE Product " +
                    "SET name = @Name," +
                    "price = @Price," +
                    "moreinfo = @Moreinfo " +
                    "WHERE id = @Id";
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Name", pd.Name);
                cmd.Parameters.AddWithValue("@Price", pd.Price);
                cmd.Parameters.AddWithValue("@Moreinfo", pd.MoreInfo);
                cmd.Parameters.AddWithValue("@Id", pd.Id);
                cmd.ExecuteNonQuery();
            }

        }




        public void Deletedb(int id)
        {
            using (var conn = new SQLiteConnection(Conn))
            {
                conn.Open();
                String sql = "DELETE FROM Product WHERE id = @id ";
                var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            


        }

    }
}
