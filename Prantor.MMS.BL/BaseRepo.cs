using Prantor.MMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class BaseRepo
    {
        private MMSDbContext _context;

        public MMSDbContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = new MMSDbContext();
                return _context;

            }
        }
    }
}
