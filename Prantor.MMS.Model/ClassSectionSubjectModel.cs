using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prantor.MMS.Model
{
    public class ClassSectionSubjectModel
    {
        [Display(Name="Class")]
        public int ClassId { get; set; }

        [Display(Name="Sections")]
        public int SectionId { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        public IEnumerable<SelectListItem> ListOfClasses { get; set; }

        public IEnumerable<SelectListItem> ListOfSections { get; set; }

        public IEnumerable<SubjectModel> ListOfSubjects { get; set; }
    }
}
