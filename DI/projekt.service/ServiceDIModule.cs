using Autofac;
using Project.Service;
using Project.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt.service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerRequest();
            builder.RegisterType<CollegeService>().As<ICollegeService>().InstancePerRequest();
        }
    }
}
