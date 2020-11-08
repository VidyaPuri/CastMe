using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CastMe.Models
{
    public class TeamMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IgHandle { get; set; }
        public string FbHandle { get; set; }
        public string Equipment { get; set; }

    }
}
