using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
namespace Project.Service.Common
{
    public interface ICollegeService
    {
        List<College> GetAllColleges();
        College GetCollegeById(int id);

        void SaveNewValue(College college);

        void UpdateCollegeAddress(int id, string address);

        void RemoveCollegeById(int id);
    }
}
