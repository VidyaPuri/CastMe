using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenProject.Web.Data
{
    public partial class RestClient
    {
        public  Task<T> GetAllProjects<T>()
        {
            return GetData<T>(ApiUrl + "project");
        }


    }
}
