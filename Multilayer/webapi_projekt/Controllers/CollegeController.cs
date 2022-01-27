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
namespace web_api_project.Controllers
{
   

    public class CollegeController : ApiController
    {
        public CollegeController() { }
        protected ICollegeService service = new CollegeService();

        [HttpGet]
        public List<College> GetAllColleges()
        {
            return service.GetAllColleges();
        }
        [HttpGet]
        public College GetCollegeById(int id)
        {
            return service.GetCollegeById(id);
        }

        [HttpPost]
        public void SaveNewValue([FromBody] College college)
        {
            service.SaveNewValue(college);
        }

        [HttpPut]
        public void UpdateCollegeAddress(int id, string address)
        {
            service.UpdateCollegeAddress(id, address);  
        }

        [HttpDelete]
        public void RemoveCollegeById(int id)
        {
            service.RemoveCollegeById(id);
        }
    }
}