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
using Projekt.Common;
using Project.Common;

namespace Project.Repository
{
    public class CollegeRepository : ICollegeRepository
    {
        SqlConnection connection = new SqlConnection(@"Server= localhost;Database=students_webapi;Trusted_Connection=True;");
        SqlCommand cmd = null;

        public async Task<List<College>> GetPagesOfCollegesAsync(Pager page)
        {
            List<College> CollegeList = new List<College>();

            cmd = new SqlCommand("Select * from College ORDER BY Name OFFSET " + ((page.PageNumber - 1) * page.ItemsPerPage) + " ROWS FETCH NEXT " + page.ItemsPerPage + " ROWS ONLY;", connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    College college = new College();
                    college.Id = int.Parse(oReader["Id"].ToString());
                    college.Name = oReader["Name"].ToString();
                    college.Address = oReader["Address"].ToString();
                    CollegeList.Add(college);
                }
            }
            connection.Close();
            return CollegeList;
        }

        public async Task<List<College>> GetFilteredCollegesAsync(Filtering filter)
        {
            List<College> CollegeList = new List<College>();

            cmd = new SqlCommand("Select * from College WHERE " + filter.FilterBy + " LIKE  '%" + filter.FilterWord + "%'", connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    College college = new College();
                    college.Id = int.Parse(oReader["Id"].ToString());
                    college.Name = oReader["Name"].ToString();
                    college.Address = oReader["Address"].ToString();
                    CollegeList.Add(college);
                }
            }
            connection.Close();
            return CollegeList;
        }

        public async Task<List<College>> GetSortedCollegesAsync(Sorting sort)
        {
            List<College> CollegeList = new List<College>();

            cmd = new SqlCommand($"Select * from College ORDER BY {sort.OrderBy} {sort.SortOrder}", connection);
            connection.Open();
            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
            {
                while (oReader.Read())
                {
                    College college = new College();
                    college.Id = int.Parse(oReader["Id"].ToString());
                    college.Name = oReader["Name"].ToString();
                    college.Address = oReader["Address"].ToString();
                    CollegeList.Add(college);
                }
            }
            connection.Close();
            return CollegeList;
        }

        public async Task<List<College>> GetAllCollegesAsync()
        {
            List<College> CollegeList = new List<College>();

            cmd = new SqlCommand("Select * from College", connection);

            connection.Open();

            using (SqlDataReader oReader = await cmd.ExecuteReaderAsync())
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

       public async Task<College> GetCollegeByIdAsync(int id) {
                College college = new College();
                cmd = new SqlCommand("Select * from College WHERE id=" + id + ";", connection);
                connection.Open();
                using (SqlDataReader oReader =await cmd.ExecuteReaderAsync())
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

       public async Task SaveNewValueAsync(College college) {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into College values('" + college.Name + "','" + college.Address + "');", connection);
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }

       public async Task UpdateCollegeAddressAsync(int id, string address) {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE College SET Address='" + (address) + "'  WHERE Id='" + id + "'";
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }

       public async Task RemoveCollegeByIdAsync(int id) {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM College WHERE Id=" + id + ";";
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
    }
}
