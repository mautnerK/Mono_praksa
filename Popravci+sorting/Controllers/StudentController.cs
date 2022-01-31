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
       
        public async Task<HttpResponseMessage> GetSortedStudents(string sortBy, string orderBy)
        {
            var sort = new Sorting();
            sort.OrderBy = orderBy;
            sort.SortOrder = sortBy;

            List<Student> SortedStudents = await service.GetSortedStudents(sort);
            return Request.CreateResponse(HttpStatusCode.OK, SortedStudents);
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
