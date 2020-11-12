using System.Collections.Generic;
using ZenProject.Web.Models;

namespace ZenProject.Web.ViewModels
{
    public class CreateProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Staff> StaffMembers { get; set; }
        public IEnumerable<Talent> TalentList { get; set; }
    }
}
