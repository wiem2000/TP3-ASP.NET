using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_tp3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
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
                                System.Diagnostics.Debug.WriteLine(" ID: "+ reader.GetInt32(0).ToString() + " First Name: " + reader.GetString(1)
                                    + " Last Name: " + reader.GetString(2) + " Email: "+ reader.GetString(3) + " DateOfBirth: "
                                    + reader.GetDateTime(4).ToString() +" Image: "+ reader.GetString(5)+" country: "+ reader.GetString(6));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //return View();
            return Content("");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}