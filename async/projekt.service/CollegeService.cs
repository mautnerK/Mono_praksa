using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Model;
using Project.Repository.Common;
using Project.Repository;
using projekt.service.Model;
namespace Project.Service
{
    public class CollegeService : ICollegeService
    {
        public CollegeService() { }
        protected IStudentRepository studentRepository = new StudentRepository();
        protected ICollegeRepository collegeRepository = new CollegeRepository();


        public async Task<List<College>> GetAllCollegesAsync() { 
            List<Student> Studenti= new List<Student>();
            List<College> Colleges = new List<College>();
            List<College> returnList = new List<College>();
            Studenti = await studentRepository.GetAllStudentsAsync();
            Colleges = await collegeRepository.GetAllCollegesAsync();
            foreach (College college in Colleges)
            {
                College colleges= new College();
                List<Student> stud = new List<Student>();
                colleges.Name= college.Name;
                colleges.Address=college.Address;
                foreach(Student student in Studenti)
                {
                    if (student.CollegeId == college.Id)
                    {
                        Student addStudent = new Student();
                        addStudent.Name = student.Name;
                        addStudent.Surname=student.Surname;
                        stud.Add(addStudent);
                    }
                    colleges.Students = stud;
                    
                }
                returnList.Add(colleges);

            }

            return returnList;
        }
        public async Task<College> GetCollegeByIdAsync(int id) {


            return await collegeRepository.GetCollegeByIdAsync(id);
        }

        public async Task SaveNewValueAsync(College college) {
            await collegeRepository.SaveNewValueAsync(college);
        }

        public async Task UpdateCollegeAddressAsync(int id, string address) {
            await collegeRepository.UpdateCollegeAddressAsync(id, address);
        }

        public async Task RemoveCollegeByIdAsync(int id) {
            await collegeRepository.RemoveCollegeByIdAsync(id);
        }
    }
}
