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
    public class CollegeRepository : ICollegeRepository
    {
        SqlConnection connection = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
        SqlCommand cmd = null;
        public List<College> GetAllColleges()
        {
            List<College> CollegeList = new List<College>();

            cmd = new SqlCommand("Select * from College", connection);

            connection.Open();

            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    College college = new College();
                    college.Id = int.Parse(oReader["Id"].ToString());
                    college.Name = oReader["Name"].ToString();
                    college.Address = oReader["Address"].ToString();
                    CollegeList.Add(college);
                }
                connection.Close();
                return CollegeList;
            }
        }
       public College GetCollegeById(int id) {
                College college = new College();
                cmd = new SqlCommand("Select * from Student WHERE id=" + id + ";", connection);
                connection.Open();
                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        college.Id = int.Parse(oReader["Id"].ToString());
                        college.Name = oReader["Name"].ToString();
                        college.Address = oReader["Address"].ToString();
                    }
                }
                connection.Close();
                return college;
            }

       public void SaveNewValue(College college) {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into College values('" + college.Id + "','" + college.Name + "','" + college.Address + "');", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }

       public void UpdateCollegeAddress(int id, string address) {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE College SET Address='" + (address) + "'  WHERE Id='" + id + "'";
                command.ExecuteNonQuery();
                connection.Close();
            }

       public void RemoveCollegeById(int id) {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM College WHERE Id=" + id + ";";
                command.ExecuteNonQuery();
                connection.Close();
            }
    }
}
