using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Model
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsSelected { get; set; }
    }
}
