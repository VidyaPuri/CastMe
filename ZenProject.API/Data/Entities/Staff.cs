using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenProject.API.Data.Entities.Enums;

namespace ZenProject.API.Data.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IgHandle { get; set; }
        public string FbHandle { get; set; }
        public string HairColor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ConfectionNumber { get; set; }
        public int FeetSize { get; set; }
        public string Alergies { get; set; }
        public string Hobbies { get; set; }
        public string Experience { get; set; }
    }
}
