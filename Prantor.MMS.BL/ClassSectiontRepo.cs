using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class ClassSectionRepo : BaseRepo
    {
        public Result<List<ClassSection>> GetAll(string key="")
        {
            var result = new Result<List<ClassSection>>();
            var context = DbContext;
            try {

                var classSections = context.ClassSection.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    classSections = classSections.Where(u => u.ClassName.ToUpper().Contains(key.ToUpper()) ||
                        u.SectionName.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = classSections;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<ClassSection> GetByID(int id)
        {
            var result = new Result<ClassSection>();
            var context = DbContext;
            try
            {
                result.Data = context.ClassSection.FirstOrDefault(u => u.ClassID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<bool> Delete(string secName,int classId)
        {
            var result = new Result<bool>();
            var context = DbContext;
            try
            {
                var classSection = context.ClassSection.FirstOrDefault(ui => ui.ClassID == classId && ui.SectionName==secName);
                if (classSection == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Class Id";
                    return result;
                }

                context.ClassSection.Remove(classSection);
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
