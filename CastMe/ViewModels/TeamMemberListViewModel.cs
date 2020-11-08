using CastMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastMe.ViewModels
{
    public class TeamMemberListViewModel
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
    }
}
