using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp_tp3.Models
{
    public class Person
    {
       // id, first_name, last_name, email, date_birth, image, country

        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Date_birth { get; set; }
        public string Image { get; set; }
        public string Country { get; set; }


    }
}