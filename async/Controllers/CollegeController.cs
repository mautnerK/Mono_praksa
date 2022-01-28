using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Project.Service.Common;
using Project.Service;
using Project.Model;
using System.Threading.Tasks;
using web_api_projekt.Models;
namespace web_api_project.Controllers

{
   

    public class CollegeController : ApiController
    {
        public CollegeController() { }
        protected ICollegeService service = new CollegeService();

        [HttpGet]
        public async Task<List<CollegeViewModel>> GetAllCollegesAsync()
        {
            List<CollegeViewModel> ReducedList = new List<CollegeViewModel>();
            List<College> WholeList = new List<College>();
            WholeList = await service.GetAllCollegesAsync();
            foreach (var college in WholeList)
            {
                CollegeViewModel collegeViewModel = new CollegeViewModel();
                collegeViewModel.Name = college.Name;
                collegeViewModel.Address = college.Address;
                collegeViewModel.StudentLista = college.Students;

                ReducedList.Add(collegeViewModel);
            }
            return ReducedList;
        }
        [HttpGet]
        public async Task<CollegeViewModel> GetCollegeByIdAsync(int id)
        {
            CollegeViewModel collegeViewModel= new CollegeViewModel();
            College college= await service.GetCollegeByIdAsync(id);
            collegeViewModel.Name = college.Name;
            collegeViewModel.Address= college.Address;
            return collegeViewModel;
        }

        [HttpPost]
        public async Task SaveNewValueAsync([FromBody] College college)
        {
            await service.SaveNewValueAsync(college);
        }

        [HttpPut]
        public async Task UpdateCollegeAddressAsync(int id, string address)
        {
            await service.UpdateCollegeAddressAsync(id, address);  
        }

        [HttpDelete]
        public async Task RemoveCollegeByIdAsync(int id)
        {
           await service.RemoveCollegeByIdAsync(id);
        }
    }
}