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
using Project.Common;
using Projekt.Common;

namespace Project.Repository
{
  
    public class StudentRepository : IStudentRepository
    {
        SqlConnection connection = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");

        SqlCommand cmd = null;



        


        public async Task<List<Student>> GetPagesOfStudentsAsync(Pager page)
        {
            List<Student> StudentList = new List<Student>();

            cmd = new SqlCommand("Select * from Student ORDER BY Name OFFSET "+((page.PageNumber-1)*page.ItemsPerPage ) +" ROWS FETCH NEXT "+page.ItemsPerPage+ " ROWS ONLY;" , connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    student.Surname = oReader["Surname"].ToString();
                    student.Address = oReader["Address"].ToString();
                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                    StudentList.Add(student);
                }
            }
            connection.Close();
            return StudentList;

        }




        public async Task<List<Student>> GetFilteredStudentsAsync(Filtering filter)
        {
            List<Student> StudentList = new List<Student>();

            cmd = new SqlCommand("Select * from Student WHERE "+filter.FilterBy+ " LIKE  '%" + filter.FilterWord+"%'", connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    student.Surname = oReader["Surname"].ToString();
                    student.Address = oReader["Address"].ToString();
                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                    StudentList.Add(student);
                }
            }
            connection.Close();
            return StudentList;
        }

        public async Task<List<Student>> GetSortedStudentsAsync(Sorting sort)
        {
            List<Student> StudentList = new List<Student>();
            
            cmd = new SqlCommand("Select * from Student ORDER BY "+sort.OrderBy+" "+sort.SortOrder,connection);
            connection.Open();
            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                                while (oReader.Read())
                                {
                                    Student student = new Student();
                                    student.Id = int.Parse(oReader["Id"].ToString());
                                    student.Name = oReader["Name"].ToString();
                                    student.Surname = oReader["Surname"].ToString();
                                    student.Address = oReader["Address"].ToString();
                                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                                    StudentList.Add(student);
                                }
                }
            connection.Close();
            return StudentList;
        }

            public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> StudentList = new List<Student>();

            cmd = new SqlCommand("Select * from Student", connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    Student student = new Student();
                    student.Id = int.Parse(oReader["Id"].ToString());
                    student.Name = oReader["Name"].ToString();
                    student.Surname = oReader["Surname"].ToString();
                    student.Address = oReader["Address"].ToString();
                    student.CollegeId = int.Parse(oReader["CollegeId"].ToString());
                    StudentList.Add(student);
                }
            }
            connection.Close();    
            return StudentList; 
        }

        public async Task<Student> GetAStudentAsync(int id)
        {
            Student student = new Student();
            cmd = new SqlCommand("Select * from Student WHERE id=" + id + ";", connection);
            connection.Open();
            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
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

        public async Task SaveNewValueAsync(Student student)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("insert into Student values ('" + student.Name + "','" + student.Surname + "','" + student.Address + "','"+student.CollegeId+"');", connection);
            await cmd.ExecuteNonQueryAsync();
            connection.Close();
        }
     
        public async Task UpdateStudentAddressAsync(int id, string address)
        {

            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Student SET Address='" + (address) + "'  WHERE Id='" + id + "'";
            await command.ExecuteNonQueryAsync();
        }

        public async Task RemoveStudentByIdAsync(int id)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Student WHERE Id=" + id + ";";
            await command.ExecuteNonQueryAsync();
        }
    }
}

