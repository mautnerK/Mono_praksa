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

namespace Zadatak_web_api.Controllers
{

    public class StudentController : ApiController
    {
        public StudentController() { }
        protected IStudentService service = new StudentService();

        
        [HttpGet]
        public async Task<HttpResponseMessage> GetAllStudentsAsync()
        {
            List  <StudentViewModel> reducedList = new List<StudentViewModel>();
            List <Student>wholeList = await service.GetAllStudentsAsync();

            foreach (var student in wholeList)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                student.College = new College();
                studentViewModel.Name = student.Name;
                studentViewModel.Surname = student.Surname;
                studentViewModel.Address = student.Address;
                studentViewModel.College = student.College.Name;
                reducedList.Add(studentViewModel);
            }
            return Request.CreateResponse(HttpStatusCode.OK, reducedList);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetStudentByIdAsync(int id)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            Student student = await service.GetAStudentAsync(id);
            studentViewModel.Name = student.Name;
            studentViewModel.Surname=student.Surname;
            studentViewModel.Address=student.Address;
            studentViewModel.College = student.College.Name;
            return Request.CreateResponse(HttpStatusCode.OK,studentViewModel);
        }

        [HttpGet]
       
        public async Task<HttpResponseMessage> GetSortedStudentsAsync(string sortBy, string orderBy)
        {
            var sort = new Sorting();
            sort.OrderBy = orderBy;
            sort.SortOrder = sortBy;

            List<Student> sortedStudents = await service.GetSortedStudentsAsync(sort);
            return Request.CreateResponse(HttpStatusCode.OK, sortedStudents);
        }

        [HttpGet]

        public async Task<HttpResponseMessage> GetFilteredStudentsAsync(string filterBy, string filterWord)
        {
            var filter = new Filtering();
            filter.FilterWord = filterWord;
            filter.FilterBy = filterBy;

            List<Student> filteredStudents = await service.GetFilteredStudentsAsync(filter);
            return Request.CreateResponse(HttpStatusCode.OK, filteredStudents);
        }


        [HttpGet]
        public async Task<HttpResponseMessage> GetPagesOfStudentsAsync(int itemsPerPage, int pageNumber)
        {
            var page = new Pager();
            page.ItemsPerPage = itemsPerPage;
            page.PageNumber = pageNumber;
            List<Student> pagesOfStudents = await service.GetPagesOfStudentsAsync(page);
            return Request.CreateResponse(HttpStatusCode.OK, pagesOfStudents);
        }

            [HttpPost]
        public async Task<HttpResponseMessage>  SaveNewValueAsync([FromBody] StudentViewModel student)
        {
            Student studentViewModel = new Student();
            studentViewModel.Name=student.Name;
            studentViewModel.Surname = student.Surname;
            studentViewModel.Address=student.Address;
            await service.SaveNewValueAsync(studentViewModel);
            return Request.CreateResponse(HttpStatusCode.OK, "Student saved");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateStudentAddressAsync(int id, string address)
        {
           await service.UpdateStudentAddressAsync(id, address);
            return Request.CreateResponse(HttpStatusCode.OK, "Student removed");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveStudentByIdAsync(int id)
        {
          await  service.RemoveStudentByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Student removed");
        }



    }
}
