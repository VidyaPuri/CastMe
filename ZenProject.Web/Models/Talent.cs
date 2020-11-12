using System;
using System.ComponentModel.DataAnnotations;
using static ZenProject.Core.Enums;

namespace ZenProject.Web.Models
{
    public class Talent
    {
        public int TalentId { get; set; }
        [Required(ErrorMessage = "Please enter the first name")]
        [Display(Name = "First name")]
        [MinLength(1)]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter the last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Please select the date of birth")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select the Talent role")]
        [Display(Name = "Role")]
        public TalentRoles Role { get; set; }

        [Required(ErrorMessage = "Please enter the phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Display(Name = "Instagram handle")]
        public string IgHandle { get; set; }

        [Display(Name = "Facebook handle")]
        public string FbHandle { get; set; }
        
        [Display(Name = "Hair color")]
        public string HairColor { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        [Display(Name = "Confection number")]
        public int ConfectionNumber { get; set; }

        [Display(Name = "Shoe size")]
        public int ShoeSize { get; set; }
        public string Alergies { get; set; }
        public string Hobbies { get; set; }
        public string Experience { get; set; }
    }
}
