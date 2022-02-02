using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
namespace Project.Model
{
    public class College : ICollege
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Address { get; set; }

        public List<Student> Students { get; set; } 

    }
}
