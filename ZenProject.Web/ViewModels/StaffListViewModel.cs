﻿using System.Collections.Generic;
using ZenProject.Web.Models;

namespace ZenProject.Web.ViewModels
{
    public class StaffListViewModel
    {
        public IEnumerable<Staff> StaffMembers { get; set; }
    }
}
