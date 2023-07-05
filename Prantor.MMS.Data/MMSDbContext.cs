using Prantor.MMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.Data
{
    public class MMSDbContext: DbContext
    {
        public MMSDbContext()
            : base("MMSDbContext")
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Madrasa> Madrasas { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassSection> ClassSection { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<ClassSectionSubject> ClassSectionSubject { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }

    }
}
