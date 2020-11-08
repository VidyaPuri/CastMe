using CastMe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CastMe.Data
{
    public interface ITeamMemberData
    {
        IEnumerable<TeamMember> GetAll();
    }
}
