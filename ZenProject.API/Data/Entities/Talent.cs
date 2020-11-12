using System;
using static ZenProject.Core.Enums;

namespace ZenProject.API.Data.Entities
{
    public class Talent
    {
        public int TalentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TalentRoles Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IgHandle { get; set; }
        public string FbHandle { get; set; }
        public string HairColor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ConfectionNumber { get; set; }
        public int ShoeSize { get; set; }
        public string Alergies { get; set; }
        public string Hobbies { get; set; }
        public string Experience { get; set; }
    }
}
