using Project.Common;
using Project.Model;
using Projekt.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Common
{
    public interface IStudentService
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
