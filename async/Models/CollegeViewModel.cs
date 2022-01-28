using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_projekt.Models
{
    public class CollegeViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Student> StudentLista { get; set; }
    }
}