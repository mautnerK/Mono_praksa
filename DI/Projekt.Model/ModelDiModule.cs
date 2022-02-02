using Autofac;
using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Model
{
    public class ModelDiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Student>().As<IStudent>().InstancePerRequest();
            builder.RegisterType<College>().As<ICollege>().InstancePerRequest();


        }
    }
}
