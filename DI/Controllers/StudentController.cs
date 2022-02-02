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
        private IStudentService studentservice;
        public StudentController(IStudentService service) { studentservice = service; }
        

        [HttpGet]
        public async Task<HttpResponseMessage> GetAllStudentsAsync(string orderBy="", string sortBy="",int itemsPerPage=3, int pageNumber=1, string filterBy="", string filterWord="")
        {


            var sort = new Sorting();
            sort.OrderBy = orderBy;
            sort.SortOrder = sortBy;
        
            var page = new Pager();
            page.ItemsPerPage = itemsPerPage;
            page.PageNumber = pageNumber;

            var filter = new Filtering();
            filter.FilterWord = filterWord;
            filter.FilterBy = filterBy;

            List<StudentViewModel> reducedList = new List<StudentViewModel>();
            List<Student> wholeList = await studentservice.GetAllStudentsAsync(sort, page,filter);
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
            Student student = await studentservice.GetAStudentAsync(id);
            studentViewModel.Name = student.Name;
            studentViewModel.Surname=student.Surname;
            studentViewModel.Address=student.Address;
            studentViewModel.College = student.College.Name;
            return Request.CreateResponse(HttpStatusCode.OK,studentViewModel);
        }

     
            [HttpPost]
        public async Task<HttpResponseMessage>  SaveNewValueAsync([FromBody] StudentViewModel student)
        {
            Student studentViewModel = new Student();
            studentViewModel.Name=student.Name;
            studentViewModel.Surname = student.Surname;
            studentViewModel.Address=student.Address;
            await studentservice.SaveNewValueAsync(studentViewModel);
            return Request.CreateResponse(HttpStatusCode.OK, "Student saved");
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateStudentAddressAsync(int id, string address)
        {
           await studentservice.UpdateStudentAddressAsync(id, address);
            return Request.CreateResponse(HttpStatusCode.OK, "Student removed");
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> RemoveStudentByIdAsync(int id)
        {
          await studentservice.RemoveStudentByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Student removed");
        }



    }
}
