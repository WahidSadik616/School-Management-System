using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Entities
{
    public class TimeTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }

       
        [StringLength(10)]
        public string SectionName { get; set; }


        [Required]
        [StringLength(50)]
        public string SubjectName { get; set; }

        [Required]
        [StringLength(20)]
        public string WeekName { get; set; }

        [Required]
        [StringLength(50)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(50)]
        public string EndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string RoomNum { get; set; }

        public int MadrasaId { get; set; }

        [ForeignKey("MadrasaId")]

        public Madrasa Madrasa { get; set; }
    }
}
