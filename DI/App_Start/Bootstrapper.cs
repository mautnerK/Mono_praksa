using AutoFacWithWebAPI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace web_api_projekt.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}