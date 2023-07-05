using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Model
{
    public class SectionsModel
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }

        public bool IsSelected { get; set; }
    }
}
