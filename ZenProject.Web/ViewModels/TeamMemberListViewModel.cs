﻿using System.Collections.Generic;
using ZenProject.Web.Models;

namespace ZenProject.Web.ViewModels
{
    public class TeamMemberListViewModel
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
    }
}
