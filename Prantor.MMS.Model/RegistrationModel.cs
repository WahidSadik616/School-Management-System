using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Model
{
    public class RegistrationModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        public string CPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }


        [Display(Name = "Email Address")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString="{0:dd-MMM-yyyy}", ApplyFormatInEditMode=true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        [Display(Name="Blood Group")]
        public int BloodGroupId { get; set; }

    }
}
