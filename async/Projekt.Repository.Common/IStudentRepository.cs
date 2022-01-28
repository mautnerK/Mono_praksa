using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IStudentRepository
    {
       Task<List<Student>> GetAllStudentsAsync();

       Task<Student> GetAStudentAsync(int id);

       Task SaveNewValueAsync(Student student);

       Task UpdateStudentAddressAsync(int id, string address);

       Task RemoveStudentByIdAsync(int id);
    }
}
