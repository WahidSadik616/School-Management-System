using Prantor.MMS.BL;
using Prantor.MMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Framework
{
    public class BaseController : Controller
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

        private UserInfoRepo _userInfoRepo;

        public UserInfoRepo UserInfoRepo
        {
            get
            {
                if (_userInfoRepo == null)
                    _userInfoRepo = new UserInfoRepo();
                return _userInfoRepo;

            }
        }


        private MadrasaRepo _madrasaRepo;

        public MadrasaRepo MadrasaRepo
        {
            get
            {
                if (_madrasaRepo == null)
                    _madrasaRepo = new MadrasaRepo();
                return _madrasaRepo;

            }
        }

        private StudentRepo _studentRepo;

        public StudentRepo StudentRepo
        {
            get
            {
                if (_studentRepo == null)
                    _studentRepo = new StudentRepo();
                return _studentRepo;

            }
        }

        private SectionRepo _sectionRepo;
        public SectionRepo SectionRepo
        {
            get
            {
                if (_sectionRepo == null)
                    _sectionRepo = new SectionRepo();
                return _sectionRepo;

            }
        }

       private ClassRepo _classRepo;
       public ClassRepo ClassRepo
        {
            get
            {
                if (_classRepo == null)
                    _classRepo = new ClassRepo();
                return _classRepo;

            }
        }


       private SubjectRepo _subjectRepo;
       public SubjectRepo SubjectRepo
       {
           get
           {
               if (_subjectRepo == null)
                   _subjectRepo = new SubjectRepo();
               return _subjectRepo;

           }
       }


       private ClassSectionRepo _classSectionRepo;
       public ClassSectionRepo ClassSectionRepo
       {
           get
           {
               if (_classSectionRepo == null)
                   _classSectionRepo = new ClassSectionRepo();
               return _classSectionRepo;

           }
       }


       private ClassSectionSubjectRepo _classSectionSubjectRepo;
       public ClassSectionSubjectRepo ClassSectionSubjectRepo
       {
           get
           {
               if (_classSectionSubjectRepo == null)
                   _classSectionSubjectRepo = new ClassSectionSubjectRepo();
               return _classSectionSubjectRepo;

           }
       }

       private TimeTableRepo _timeTableRepo;
       public TimeTableRepo TimeTableRepo
       {
           get
           {
               if (_timeTableRepo == null)
                   _timeTableRepo = new TimeTableRepo();
               return _timeTableRepo;

           }
       }
    }
}
