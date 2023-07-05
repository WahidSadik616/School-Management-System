using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class SubjectRepo : BaseRepo
    {
        public Result<List<Subject>> GetAll(string key="")
        {
            var result = new Result<List<Subject>>();
            var context = DbContext;
            try {

                var subjects = context.Subject.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    subjects = subjects.Where(u => u.Name.ToUpper().Contains(key.ToUpper()) ||
                        u.SubjectCode.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = subjects;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Subject> GetByID(int id)
        {
            var result = new Result<Subject>();
            var context = DbContext;
            try
            {
                result.Data = context.Subject.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Subject> Save(Subject u)
        {
            
            var result = new Result<Subject>();
            var context = DbContext;
            try
            {
                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }
 

                var objToSave = context.Subject.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {   
                    objToSave = new Subject();
                    context.Subject.Add(objToSave);

                   
                }    
               
                objToSave.Name = u.Name;
                objToSave.SubjectCode = u.SubjectCode;                
                objToSave.SubjectType = u.SubjectType;
                objToSave.MadrasaId = u.MadrasaId;

                result.Data = objToSave;

                context.SaveChanges();

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<bool> Delete(int id)
        {
            var result = new Result<bool>();
            var context = DbContext;
            try
            {
                var subject = context.Subject.FirstOrDefault(ui => ui.ID == id);
                if (subject == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.Subject.Remove(subject);
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
