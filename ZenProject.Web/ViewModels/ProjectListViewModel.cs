using System.Collections.Generic;
using ZenProject.Web.Models;

namespace ZenProject.Web.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Project> ProjectList { get; set; }
    }
}
