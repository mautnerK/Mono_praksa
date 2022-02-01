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
        public CollegeService() { }
        protected IStudentRepository studentRepository = new StudentRepository();
        protected ICollegeRepository collegeRepository = new CollegeRepository();


        public async Task<List<College>> GetAllCollegesAsync() { 
            IList<Student> studentsList = await studentRepository.GetAllStudentsAsync();
            List<College> collegesList = await collegeRepository.GetAllCollegesAsync();
            List<College> returnList = new List<College>();

            foreach (College college in collegesList)
            {
                List<Student> stud = new List<Student>();
              
                college.Students=studentsList.Where(s => s.CollegeId==college.Id).ToList();

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
        public async Task<List<College>> GetSortedCollegesAsync(Sorting sort)
        {
            return await collegeRepository.GetSortedCollegesAsync(sort);
        }
        public async Task<List<College>> GetFilteredCollegesAsync(Filtering filter)
        {
            return await collegeRepository.GetFilteredCollegesAsync(filter);
        }

        public async Task<List<College>> GetPagesOfCollegesAsync(Pager page)
        {
            return await collegeRepository.GetPagesOfCollegesAsync(page);
        }

    }
}
