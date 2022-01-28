using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
namespace Project.Repository.Common
{
    public interface ICollegeRepository
    {
        Task<List<College>> GetAllCollegesAsync();
        Task<College> GetCollegeByIdAsync(int id);

        Task SaveNewValueAsync(College college);

        Task UpdateCollegeAddressAsync(int id, string address);

        Task RemoveCollegeByIdAsync(int id);
    }
}
