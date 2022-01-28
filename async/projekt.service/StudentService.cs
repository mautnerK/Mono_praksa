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

        protected IStudentRepository studentRepository = new StudentRepository();
        protected ICollegeRepository collegeRepository = new CollegeRepository();
        public async Task<List<Student>> GetAllStudentsAsync() {
            List<Student> Students = new List<Student>();
            List<Student> StudentsWithColleges = new List<Student>();
            Students=await studentRepository.GetAllStudentsAsync();
            foreach(Student student in Students)
            {
                Student Stud = new Student();
                Stud.College = new College();
                College college = new College();
                Stud.Name=student.Name;
                Stud.Surname = student.Surname;
                Stud.Address = student.Address;
                college= await collegeRepository.GetCollegeByIdAsync(student.Id);
                Stud.College = college;
                StudentsWithColleges.Add(Stud);
            }

            return StudentsWithColleges;
        }



        public async Task<Student> GetAStudentAsync(int id) {
            Student student = new Student();
            Student studentWithCollege = new Student();
            College college = new College();
            studentWithCollege.College=new College();
            student= await studentRepository.GetAStudentAsync(id);
            college= await collegeRepository.GetCollegeByIdAsync(student.CollegeId);
            studentWithCollege.Name=student.Name;
            studentWithCollege.Surname=student.Surname;
            studentWithCollege.Address = student.Address;
            studentWithCollege.College.Name=college.Name;
            return studentWithCollege;
        }

        public async Task SaveNewValueAsync(Student student) {
           await  studentRepository.SaveNewValueAsync(student);
        }

        public async Task UpdateStudentAddressAsync(int id, string address) {
           await studentRepository.UpdateStudentAddressAsync(id, address);
        }

        public async Task RemoveStudentByIdAsync(int id) { 
            await studentRepository.RemoveStudentByIdAsync(id);
        }
    }
}
