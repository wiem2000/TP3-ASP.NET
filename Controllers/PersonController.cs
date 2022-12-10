using asp_tp3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_tp3.Controllers
{
    public class PersonController : Controller
    {
        public List<Person> people = new List<Person>();
        // GET: Person
      

        public ActionResult All()
        {
            Personal_info personal_Info = new Personal_info();
           
            return View("GetAllPerson", personal_Info.GetAllPerson());
        }


        public ActionResult ById(int id)
        {
            Personal_info personal_Info = new Personal_info();
            Person p = personal_Info.GetPerson(id);
            if (p.Id==0)
            {
                ViewBag.ERROR = "Cet ID est invalide";
            }
            return View("GetPerson", p);
        }



        public ActionResult FormSearch()
        {
            Person p = new Person();
            return View("FormSearch",p);

        }

       
        public ActionResult PersonSearch()
        {

            Person p = new Person();
            p.Id=0;
            string first_name= Request.Form["First_name"];
            string country = Request.Form["Country"];

            try
            {
                string connectionString = @"Data Source=C:\sqlite\database.db;Version=3;DateTimeFormat=Ticks";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM personal_info WHERE UPPER(first_name)=UPPER(@first_name) and UPPER(country)=UPPER(@country)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", first_name);
                        cmd.Parameters.AddWithValue("@country", country);
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
                            else
                            {
                                ViewBag.ERROR = "Ces infos sont invalides";
                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Redirect("/Person/" + p.Id);

        }
    }
}