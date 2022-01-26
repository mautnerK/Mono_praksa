using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;


namespace Zadatak_web_api.Controllers
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }
    }

    public class StudentController : ApiController
    {
        SqlConnection _Con = null;
        SqlCommand _cmd = null;
        SqlDataReader rd = null;
        SqlTransaction _Transation;

     

        static List<Student> StudentList = new List<Student>();

        [HttpGet]
        public HttpResponseMessage GetAllStudents()
        {
  
            _Con = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
            
                _cmd = new SqlCommand("Select * from Student", _Con);
            
                _Con.Open();

            using (SqlDataReader oReader = _cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    StudentList.Add(student);
                }

            }
            _Con.Close();
                return Request.CreateResponse(HttpStatusCode.OK, StudentList);
            }
        

        [HttpGet]
        public HttpResponseMessage GetAStudent(int id)
        {
            _Con = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
            _cmd = new SqlCommand("Select * from Student WHERE id="+id+";", _Con);
            _Con.Open();
            using (SqlDataReader oReader = _cmd.ExecuteReader()) {
                while (oReader.Read())
            {
                Student student = new Student();
                student.Id = int.Parse(oReader["Id"].ToString());
                student.Name = oReader["Name"].ToString();
                student.Surname = oReader["Surname"].ToString();
                student.Address = oReader["Address"].ToString();
                StudentList.Add(student);
            }
        }
        _Con.Close();
                return Request.CreateResponse(HttpStatusCode.OK, StudentList);
}

        [HttpPost]
        public HttpResponseMessage SaveNewValue([FromBody] Student student)
        {
            _Con = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
            _Con.Open();
            SqlCommand cmd = new SqlCommand("insert into Student values('"+student.Id+"','"+student.Name+"','"+student.Surname+"','"+student.Address+"');", _Con);
            cmd.ExecuteNonQuery();
            _Con.Close();
            return Request.CreateResponse(HttpStatusCode.OK, StudentList);
        }

        [HttpPut]
        public HttpResponseMessage UpdateStudentAddress( int id, string address)
        {
           
            _Con = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
            _Con.Open();
                SqlCommand command = _Con.CreateCommand();
                command.CommandText = "UPDATE Student SET Address='"+(address)+"'  WHERE Id='" +id +"'";
            command.ExecuteNonQuery();
            return Request.CreateResponse(HttpStatusCode.OK, "Updated");
        }
        

        [HttpDelete]
        public HttpResponseMessage RemoveStudentById(int id)
        {
            _Con = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
            _Con.Open();
            SqlCommand command = _Con.CreateCommand();
            command.CommandText = "DELETE FROM Student WHERE Id=" + id +";" ;
            command.ExecuteNonQuery();
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }  
    }
}
