using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;

namespace Project.Service
{
    public class StudentService : IStudentService
    {
        public StudentService() { }

        protected IStudentRepository repository = new StudentRepository();
        public List<Student> GetAllStudents() { 
            return repository.GetAllStudents();
        }



        public Student GetAStudent(int id) {
            return repository.GetAStudent(id);
        }

        public void SaveNewValue(Student student) {
            repository.SaveNewValue(student);
        }

        public void UpdateStudentAddress(int id, string address) {
            repository.UpdateStudentAddress(id, address);
        }

        public void RemoveStudentById(int id) { 
            repository.RemoveStudentById(id);
        }
    }
}
