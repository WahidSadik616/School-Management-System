using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class ClassSectionSubjectRepo : BaseRepo
    {
        public Result<List<ClassSectionSubject>> GetAll(string key="")
        {
            var result = new Result<List<ClassSectionSubject>>();
            var context = DbContext;
            try {

                var classSectionSubjects = context.ClassSectionSubject.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    classSectionSubjects = classSectionSubjects.Where(u => u.ClassName.ToUpper().Contains(key.ToUpper()) ||
                        u.SectionName.ToUpper().Contains(key.ToUpper())     ||
                        u.SubjectName.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = classSectionSubjects;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<ClassSectionSubject> GetByID(int id)
        {
            var result = new Result<ClassSectionSubject>();
            var context = DbContext;
            try
            {
                result.Data = context.ClassSectionSubject.FirstOrDefault(u => u.ClassID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<bool> Delete(string subName,int secID)
        {
            var result = new Result<bool>();
            var context = DbContext;
            try
            {
                var classSectionSubject = context.ClassSectionSubject.FirstOrDefault(ui => ui.SubjectName == subName && ui.SectionID==secID);
                if (classSectionSubject == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Section Id";
                    return result;
                }

                context.ClassSectionSubject.Remove(classSectionSubject);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

    }
}
