using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Zadatak_web_api.Controllers
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StudentController : ApiController
    {
        static List<Student> StudentList = new List<Student>() {
        new Student() { Id = 1, Name ="Karlo"},
        new Student() { Id = 2, Name ="Marko"},
        new Student() { Id = 3, Name ="Ivan"},
        new Student() { Id = 4, Name ="Jozo"}
      };

        [HttpGet]
        public HttpResponseMessage GetAllStudents()
        {
            if (StudentList.Count == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Nema studenata");
            }
            return Request.CreateResponse(HttpStatusCode.OK,StudentList);
        }

        [HttpGet]
        public HttpResponseMessage GetAStudent(int id)
        {
            var IdStudent = new Student();
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Ne može biti 0 ili negativno");
            }
            if (StudentList.Any(p => p.Id == id))
            {
                IdStudent = StudentList.Where(p => p.Id == id).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, IdStudent);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Nema studenata"); 
        }

        [HttpPost]
        public HttpResponseMessage SaveNewValue([FromBody] Student student)
        {
            StudentList.Add(student);
            return Request.CreateResponse(HttpStatusCode.OK, StudentList);
        }

        [HttpPut]
        public HttpResponseMessage UpdateValue(int id, string name)
        {
            var UpdatedStudent = new Student();
            if (id <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ne može biti 0 ili negativno");
            }
           if( StudentList.Any(p => p.Id == id)){
              UpdatedStudent= StudentList.Where(p=>p.Id == id).FirstOrDefault();
              UpdatedStudent.Name = name;
                return Request.CreateResponse(HttpStatusCode.OK, StudentList);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nema studenata");
        }

        [HttpDelete]
        public HttpResponseMessage RemoveValue(int id)
        {
            var DeletedStudent = new Student();
            if (id < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Ne može biti negativno");
            }
            if (StudentList.Any(p => p.Id == id))
            {
                DeletedStudent = StudentList.Where(p => p.Id == id).FirstOrDefault();
                StudentList.Remove(DeletedStudent);
                return Request.CreateResponse(HttpStatusCode.OK, StudentList);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nema studenata");
        }
    }
}
