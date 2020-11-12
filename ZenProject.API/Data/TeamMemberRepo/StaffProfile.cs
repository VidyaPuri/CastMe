using AutoMapper;
using ZenProject.API.Models;
using ZenProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenProject.API.Data.TeamMemberRepo
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffModel>()
                .ReverseMap();
        }
    }
}
