using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class SectionRepo : BaseRepo
    {
        public Result<List<Section>> GetAll(string key="")
        {
            var result = new Result<List<Section>>();
            var context = DbContext;
            try {

                var users = context.Section.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    users = users.Where(u => u.Name.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = users;
                
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Section> GetByID(int id)
        {
            var result = new Result<Section>();
            var context = DbContext;
            try
            {
                result.Data = context.Section.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Section> Save(Section u)
        {
            
            var result = new Result<Section>();
            var context = DbContext;
            try
            {
                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

               
                var objToSave = context.Section.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {   
                    objToSave = new Section();
                    context.Section.Add(objToSave);

                   
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
                var section = context.Section.FirstOrDefault(ui => ui.ID == id);
                if (section == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.Section.Remove(section);


                var allSections = context.Section.ToList();
                var allClassSections = context.ClassSection.ToList();

                for (int i = 0; i < allSections.Count;i++ )
                {
                    if (allSections[i].ID == id)
                    {
                        for (int j = 0; j < allClassSections.Count; j++)
                        {
                            if(allClassSections[j].SectionID==allSections[i].ID)
                            {
                                context.ClassSection.Remove(allClassSections[j]);
                            }
 
                        }
                    }
                }

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
