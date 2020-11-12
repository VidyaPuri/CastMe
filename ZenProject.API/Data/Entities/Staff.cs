using System;
using static ZenProject.Core.Enums;

namespace ZenProject.Data.Entities
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StaffRoles Role { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IgHandle { get; set; }
        public string FbHandle { get; set; }
        public string Equipment { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
