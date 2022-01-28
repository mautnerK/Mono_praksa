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
namespace Zadatak_web_api.Controllers
{

    public class StudentController : ApiController
    {
        public StudentController() { }
        protected IStudentService service = new StudentService();

        [HttpGet]
        public async Task<List<StudentViewModel>> GetAllStudentsAsync()
        {
            List  <StudentViewModel> ReducedList = new List<StudentViewModel>();
            List <Student>WholeList=new List<Student>();
            WholeList = await service.GetAllStudentsAsync();

           foreach(var student in WholeList)
            {
                StudentViewModel studentViewModel = new StudentViewModel();
                student.College = new College();
                studentViewModel.Name = student.Name;
                studentViewModel.Surname = student.Surname;
                studentViewModel.Address = student.Address;
                studentViewModel.college = student.College.Name;
                ReducedList.Add(studentViewModel);
            }
            return ReducedList;
        }
        [HttpGet]
        public async Task<StudentViewModel> GetStudentByIdAsync(int id)
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            Student student = new Student();
            student = await service.GetAStudentAsync(id);
            studentViewModel.Name = student.Name;
            studentViewModel.Surname=student.Surname;
            studentViewModel.Address=student.Address;
            studentViewModel.college = student.College.Name;
            return studentViewModel;
        }

        [HttpPost]
        public async Task  SaveNewValueAsync([FromBody] Student student)
        {
            await service.SaveNewValueAsync(student);
        }

        [HttpPut]
        public async Task UpdateStudentAddressAsync(int id, string address)
        {
           await service.UpdateStudentAddressAsync(id, address);
        }

        [HttpDelete]
        public async Task RemoveStudentByIdAsync(int id)
        {
          await  service.RemoveStudentByIdAsync(id);
        }
    }
}
