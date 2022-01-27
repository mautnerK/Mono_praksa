using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Data.SqlClient;
using Project.Repository.Common;
using Project.Model;
namespace Project.Repository
{
  
    public class StudentRepository : IStudentRepository
    {
       

        SqlConnection connection = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
        SqlCommand cmd = null;

       

        public List<Student> GetAllStudents()
        {
            List<Student> StudentList = new List<Student>();

            cmd = new SqlCommand("Select * from Student", connection);

            connection.Open();

            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    student.Surname = (oReader["Surname"].ToString());
                    student.Address = oReader["Address"].ToString();
                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                    StudentList.Add(student);
                }
            }
            connection.Close();
            return StudentList;
        }

        public Student GetAStudent(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("Select * from Student WHERE id=" + id + ";", connection);
            connection.Open();
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    student.Surname = oReader["Surname"].ToString();
                    student.Address = oReader["Address"].ToString();
                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                }
            }
            connection.Close();
            return student;
        }

        public void SaveNewValue(Student student)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Student values ('" + student.Name + "','" + student.Surname + "','" + student.Address + "','"+student.CollegeId+"');", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
     
        public void UpdateStudentAddress(int id, string address)
        {

            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Student SET Address='" + (address) + "'  WHERE Id='" + id + "'";
            command.ExecuteNonQuery();
        }

        public void RemoveStudentById(int id)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Student WHERE Id=" + id + ";";
            command.ExecuteNonQuery();
        }
    }
}

