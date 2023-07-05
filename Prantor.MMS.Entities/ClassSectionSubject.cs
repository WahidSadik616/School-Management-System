using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Entities
{
    public class ClassSectionSubject
    {
        [Key, Column(Order = 0)]
        public int ClassID { get; set; }

        [Key, Column(Order = 1)]
        public int SectionID { get; set; }

        [Key, Column(Order = 2)]
        public int SubjectID { get; set; }

        [Key, Column(Order = 3)]
        public string SectionName { get; set; }

        [Key, Column(Order = 4)]
        public string ClassName { get; set; }

        [Key, Column(Order = 5)]
        public string SubjectName { get; set; }

        public int MadrasaId { get; set; }

        [ForeignKey("MadrasaId")]

        public Madrasa Madrasa { get; set; }

    }
}
