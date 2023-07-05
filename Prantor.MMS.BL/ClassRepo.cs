using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class ClassRepo : BaseRepo
    {
        public Result<List<Class>> GetAll(string key="")
        {
            var result = new Result<List<Class>>();
            var context = DbContext;
            try {

                var classes = context.Class.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    classes = classes.Where(u => u.Name.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = classes;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Class> GetByID(int id)
        {
            var result = new Result<Class>();
            var context = DbContext;
            try
            {
                result.Data = context.Class.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Class> Save(Class u)
        {
            
            var result = new Result<Class>();
            var context = DbContext;
            try
            {
                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

               
                var objToSave = context.Class.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {   
                    objToSave = new Class();
                    context.Class.Add(objToSave);

                   
                }    
               
                objToSave.Name = u.Name;
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
                var _class = context.Class.FirstOrDefault(ui => ui.ID == id);
                if (_class == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.Class.Remove(_class);
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
