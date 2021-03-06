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
       List<Student> GetAllStudents();

       Student GetAStudent(int id);

       void SaveNewValue(Student student);

       void UpdateStudentAddress(int id, string address);

       void RemoveStudentById(int id);
    }
}
