using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository;
using Project.Model;
using Project.Repository.Common;
using Project.Service.Common;
using Project.Common;
using Projekt.Common;

namespace Project.Service
{
    public class StudentService : IStudentService
    {
        public StudentService() { }

        protected IStudentRepository studentRepository = new StudentRepository();
        protected ICollegeRepository collegeRepository = new CollegeRepository();
        public async Task<List<Student>> GetAllStudentsAsync() {
            List<Student> Students = await studentRepository.GetAllStudentsAsync();
            List<Student> StudentsWithColleges = new List<Student>();
            foreach(Student student in Students)
            {
                Student Stud = student;
                Stud.College = await collegeRepository.GetCollegeByIdAsync(student.Id);
                College college = new College();
                StudentsWithColleges.Add(Stud);
            }
            return StudentsWithColleges;
        }

        public async Task<Student> GetAStudentAsync(int id) {
            Student studentWithCollege = await studentRepository.GetAStudentAsync(id);
            College college = await collegeRepository.GetCollegeByIdAsync(studentWithCollege.CollegeId);
            studentWithCollege.College=new College();
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
        public async Task<List<Student>> GetSortedStudentsAsync(Sorting sort)
        {
          return  await studentRepository.GetSortedStudentsAsync(sort);
        }
        public async Task<List<Student>> GetFilteredStudentsAsync(Filtering filter)
        {
            return await studentRepository.GetFilteredStudentsAsync(filter);
        }

        public async Task<List<Student>> GetPagesOfStudentsAsync(Pager page)
        {
            return await studentRepository.GetPagesOfStudentsAsync(page);
        }

        
    }
}
