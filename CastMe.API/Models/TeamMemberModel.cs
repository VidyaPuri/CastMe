using CastMe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastMe.API.Models
{
    public class TeamMemberModel
    {
        public int TeamMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IgHandle { get; set; }
        public string FbHandle { get; set; }
        public string Equipment { get; set; }
    }
}
