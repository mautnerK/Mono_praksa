using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Common;
using Project.Model;
using Projekt.Common;

namespace Project.Service.Common
{
    public interface ICollegeService
    {

        Task<List<College>> GetAllCollegesAsync(Sorting sort, Pager page, Filtering filter);

        Task<College> GetCollegeByIdAsync(int id);

        Task SaveNewValueAsync(College college);

        Task UpdateCollegeAddressAsync(int id, string address);

        Task RemoveCollegeByIdAsync(int id);
       
    }
}
