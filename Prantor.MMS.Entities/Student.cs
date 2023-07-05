using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(100)]
        public string FatherNid { get; set; }

        [Required]
        [StringLength(100)]
        public string MotherNid { get; set; }
        
        [Required]
        [StringLength(500)]
        public string MotherName { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(500)]
        public string Address { get; set; }

        
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string DateOfBirth { get; set; }

       
        public int GenderId { get; set; }

        public int BloodGroupId { get; set; }

        public int MadrasaId { get; set; }

        [ForeignKey("MadrasaId")]

        public Madrasa Madrasa { get; set; }
    }
}
