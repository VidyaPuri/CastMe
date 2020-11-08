using CastMe.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CastMe.Data
{
    public class InMemoryTeamMemberData : ITeamMemberData
    {
        List<TeamMember> _teamMembers;

        public InMemoryTeamMemberData()
        {
            _teamMembers = new List<TeamMember>()
            {
                new TeamMember
                {
                    TeamMemberId = 1,
                    FirstName = "Gaj",
                    LastName = "Črešnik",
                    Role = Role.Camera,
                    Email = "gc@gmail.com",
                    PhoneNumber = "040-123-456",
                    IgHandle = "instagram\\gajsl",
                    FbHandle = "facebook\\gajsl",
                    Equipment = "Kamera - Sony, Studijske luči"
                },
                 new TeamMember
                {
                    TeamMemberId = 2,
                    FirstName = "Bob",
                    LastName = "Sabath",
                    Role = Role.Producer,
                    Email = "bs@gmail.com",
                    PhoneNumber = "040-334-555",
                    IgHandle = "instagram\\bobby",
                    FbHandle = "facebook\\bobby",
                    Equipment = ""
                },
                new TeamMember
                {
                    TeamMemberId = 2,
                    FirstName = "Annie",
                    LastName = "Buzzer",
                    Role = Role.MakeUp,
                    Email = "ab@gmail.com",
                    PhoneNumber = "031-435-725",
                    IgHandle = "instagram\\annieMUA",
                    FbHandle = "facebook\\annieMUA",
                    Equipment = "Make up equipment"
                }
            };
        }

        public IEnumerable<TeamMember> GetAll()
        {
            return from tm in _teamMembers
                   orderby tm.LastName
                   select tm;
        }
    }
}
