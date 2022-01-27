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
namespace Zadatak_web_api.Controllers
{

    public class StudentController : ApiController
    {
        public StudentController() { }
        protected IStudentService service = new StudentService();

        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return service.GetAllStudents();
        }
        [HttpGet]
        public Student GetStudentById(int id)
        {
            return service.GetAStudent(id);
        }

        [HttpPost]
        public void SaveNewValue([FromBody] Student student)
        {
            service.SaveNewValue(student);
        }

        [HttpPut]
        public void UpdateStudentAddress(int id, string address)
        {
            service.UpdateStudentAddress(id, address);
        }

        [HttpDelete]
        public void RemoveStudentById(int id)
        {
            service.RemoveStudentById(id);
        }
    }
}
