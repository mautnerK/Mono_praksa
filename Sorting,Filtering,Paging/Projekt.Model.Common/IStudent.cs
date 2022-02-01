using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IStudent
    {
         int Id { get; set; }
         string Name { get; set; }
         string Surname { get; set; }
         string Address { get; set; }

      

    }
}
