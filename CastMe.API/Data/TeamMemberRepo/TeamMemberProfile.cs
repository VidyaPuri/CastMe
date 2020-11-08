using AutoMapper;
using CastMe.API.Models;
using CastMe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastMe.API.Data.TeamMemberRepo
{
    public class TeamMemberProfile : Profile
    {
        public TeamMemberProfile()
        {
            CreateMap<TeamMember, TeamMemberModel>()
                .ReverseMap();
        }
    }
}
