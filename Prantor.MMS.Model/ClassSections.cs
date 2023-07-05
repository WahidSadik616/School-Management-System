using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Model
{
    public class ClassSections
    {
        public int ClassId { get; set; }

        public IEnumerable<SelectListItem> ListOfClasses { get; set; }

        public IEnumerable<SelectListItem> ListOfSections { get; set; }
    }
}
