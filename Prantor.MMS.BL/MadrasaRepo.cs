using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class MadrasaRepo:BaseRepo
    {
        public Result<List<Madrasa>> GetAll(string key = "")
        {
            var result = new Result<List<Madrasa>>();
            var context = DbContext;
            try
            {

                var madrasas = context.Madrasas.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    madrasas = madrasas.Where(u => u.Name.ToUpper().Contains(key.ToUpper()) ||
                        u.Address.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = madrasas;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<Madrasa> GetByID(int id)
        {
            var result = new Result<Madrasa>();
            var context = DbContext;
            try
            {
                result.Data = context.Madrasas.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }
        public Result<Madrasa> Save(Madrasa u)
        {

            var result = new Result<Madrasa>();
            var context = DbContext;
            try
            {
                var objToSave = context.Madrasas.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {
                    objToSave = new Madrasa();
                    context.Madrasas.Add(objToSave);
                }


                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

                if (string.IsNullOrEmpty(u.Address))
                {
                    result.HasError = true;
                    result.Message = "Invalid Address";
                    return result;
                }

                if (string.IsNullOrEmpty(u.ContactNo))
                {
                    result.HasError = true;
                    result.Message = "Invalid Phone";
                    return result;
                }

                if (string.IsNullOrEmpty(u.DirectorName))
                {
                    result.HasError = true;
                    result.Message = "Invalid Director";
                    return result;
                }

                
                objToSave.Name = u.Name;
                objToSave.Address = u.Address;
                objToSave.DirectorName = u.DirectorName;
                objToSave.ContactNo = u.ContactNo;

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
                var madrasa = context.Madrasas.FirstOrDefault(ui => ui.ID == id);
                if (madrasa == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.Madrasas.Remove(madrasa);
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
