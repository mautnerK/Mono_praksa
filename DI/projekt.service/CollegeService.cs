using System.Collections.Generic;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Model;
using Project.Repository.Common;
using Project.Repository;
using System.Linq;
using Projekt.Common;
using Project.Common;

namespace Project.Service
{
    public class CollegeService : ICollegeService
    {
    
        protected ICollegeRepository collegeRepository { get; private set; }

        public CollegeService(ICollegeRepository repository) { collegeRepository = repository; }
        protected IStudentRepository studentRepository = new StudentRepository();


        
       

        public async Task<List<College>> GetAllCollegesAsync(Sorting sort, Pager page, Filtering filter)
        {
            List<Student> studentsList = await studentRepository.GetAllStudentsAsync();
            List<College> collegesList = await collegeRepository.GetAllCollegesAsync(sort, page,filter);
            List<College> returnList = new List<College>();

            foreach (College college in collegesList)
            {
                List<Student> stud = new List<Student>();

                college.Students = studentsList.Where(s => s.CollegeId == college.Id).ToList();

                returnList.Add(college);
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
