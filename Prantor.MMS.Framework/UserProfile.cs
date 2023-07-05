using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Framework
{
    public class UserProfile
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public int UserTypeID { get; set; }

        public int GenderID { get; set; }

        public int BloodGroupId { get; set; }

        public int StatusId { get; set; }

        public int MadrasaID { get; set; }

        public string Madrasa { get; set; }

    }
}
