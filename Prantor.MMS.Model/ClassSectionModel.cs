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
    public class ClassSectionModel
    {
        [Display(Name="Class")]
        public int ClassId { get; set; }

        [Display(Name="Sections")]
        public int SectionId { get; set; }
        public IEnumerable<SelectListItem> ListOfClasses { get; set; }

        public IEnumerable<SectionsModel> ListOfSections { get; set; }
    }
}
