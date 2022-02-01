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
using Project.Common;
using Projekt.Common;

namespace web_api_project.Controllers

{
   

    public class CollegeController : ApiController
    {
        public CollegeController() { }
        protected ICollegeService service = new CollegeService();

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllCollegesAsync()
        {
            List<CollegeViewModel> reducedList = new List<CollegeViewModel>();
            List<College> wholeList = new List<College>();
            List<StudentViewModel> list = new List<StudentViewModel>();
            wholeList = await service.GetAllCollegesAsync();
            foreach (var college in wholeList)
            {
                CollegeViewModel collegeViewModel = new CollegeViewModel();
                collegeViewModel.Name = college.Name;
                collegeViewModel.Address = college.Address;

                collegeViewModel.StudentLista = college.Students.Select(s => new StudentViewModel
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    Address = s.Address,
                    College = college.Name
                }).ToList();
                reducedList.Add(collegeViewModel);
            }
            return Request.CreateResponse(HttpStatusCode.OK, reducedList);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetCollegeByIdAsync(int id)
        {
            CollegeViewModel collegeViewModel= new CollegeViewModel();
            College college= await service.GetCollegeByIdAsync(id);
            collegeViewModel.Name = college.Name;
            collegeViewModel.Address= college.Address;
            return Request.CreateResponse(HttpStatusCode.OK, collegeViewModel);
        }
        [HttpGet]

        public async Task<HttpResponseMessage> GetSortedCollegesAsync(string sortBy, string orderBy)
        {
            var sort = new Sorting();
            sort.OrderBy = orderBy;
            sort.SortOrder = sortBy;

            List<College> sortedColleges = await service.GetSortedCollegesAsync(sort);
            return Request.CreateResponse(HttpStatusCode.OK, sortedColleges);
        }

        [HttpGet]

        public async Task<HttpResponseMessage> GetFilteredCollegesAsync(string filterBy, string filterWord)
        {
            var filter = new Filtering();
            filter.FilterWord = filterWord;
            filter.FilterBy = filterBy;

            List<College> filteredColleges = await service.GetFilteredCollegesAsync(filter);
            return Request.CreateResponse(HttpStatusCode.OK, filteredColleges);
        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetPagesOfCollegesAsync(int itemsPerPage, int pageNumber)
        {
            var page = new Pager();
            page.ItemsPerPage = itemsPerPage;
            page.PageNumber = pageNumber;
            List<College> pagesOfColleges = await service.GetPagesOfCollegesAsync(page);
            return Request.CreateResponse(HttpStatusCode.OK, pagesOfColleges);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> SaveNewValueAsync([FromBody] College college)
        {
            await service.SaveNewValueAsync(college);
            return Request.CreateResponse(HttpStatusCode.OK, "Saved new college");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateCollegeAddressAsync(int id, string address)
        {
            await service.UpdateCollegeAddressAsync(id, address);
            return Request.CreateResponse(HttpStatusCode.OK, "College updated");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveCollegeByIdAsync(int id)
        {
           await service.RemoveCollegeByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, "College removed");
        }
    }
}