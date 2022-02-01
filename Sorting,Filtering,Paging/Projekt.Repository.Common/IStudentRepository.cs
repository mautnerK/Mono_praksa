using Project.Common;
using Projekt.Common;
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

        Task<List<Student>> GetSortedStudentsAsync(Sorting sort);

        Task<List<Student>> GetFilteredStudentsAsync(Filtering filter);

        Task<List<Student>> GetPagesOfStudentsAsync(Pager page);

     
    }
}
