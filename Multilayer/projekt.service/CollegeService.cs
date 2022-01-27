using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Service.Common;
using Project.Model;
using Project.Repository.Common;
using project.repository;

namespace Project.Service
{
    public class CollegeService : ICollegeService
    {
        public CollegeService() { }
        protected ICollegeRepository repository = new CollegeRepository();
        public List<College> GetAllColleges() { 
            return repository.GetAllColleges();
        }
        public College GetCollegeById(int id) {
            return repository.GetCollegeById(id);
        }

        public void SaveNewValue(College college) {
            repository.SaveNewValue(college);
        }

        public void UpdateCollegeAddress(int id, string address) {
            repository.UpdateCollegeAddress(id, address);
        }

        public void RemoveCollegeById(int id) {
            repository.RemoveCollegeById(id);
        }
    }
}
