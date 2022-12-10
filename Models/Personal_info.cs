using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace asp_tp3.Models
{
    public class Personal_info
    {
     
        public List<Person> GetAllPerson()
        {
            List<Person> people = new List<Person>();
            try
            {
                string connectionString = @"Data Source=C:\sqlite\database.db;Version=3;DateTimeFormat=Ticks";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM personal_info";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Person p = new Person();
                                p.Id = reader.GetInt32(0);
                                p.First_name = reader.GetString(1);
                                p.Last_name = reader.GetString(2);
                                p.Email = reader.GetString(3);
                                p.Date_birth = reader.GetDateTime(4).ToString();
                                p.Image = reader.GetString(5);
                                p.Country = reader.GetString(6);
                                people.Add(p);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return people;
        }

        public Person GetPerson(int id)
        {
            Person p = new Person();
            try
            {
                string connectionString = @"Data Source=C:\sqlite\database.db;Version=3;DateTimeFormat=Ticks";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM personal_info WHERE id=@id";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    p.Id = reader.GetInt32(0);
                                    p.First_name = reader.GetString(1);
                                    p.Last_name = reader.GetString(2);
                                    p.Email = reader.GetString(3);
                                    p.Date_birth = reader.GetDateTime(4).ToString();
                                    p.Image = reader.GetString(5);
                                    p.Country = reader.GetString(6);
                               }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return p;
        }





    }
}