using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class TimeTableRepo : BaseRepo
    {
        public Result<List<TimeTable>> GetAll(string key="")
        {
            var result = new Result<List<TimeTable>>();
            var context = DbContext;
            try {

                var timeTables = context.TimeTable.ToList();

                
                result.Data = timeTables;
                
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<TimeTable> GetByID(int id)
        {
            var result = new Result<TimeTable>();
            var context = DbContext;
            try
            {
                result.Data = context.TimeTable.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<TimeTable> Save(TimeTable u)
        {

            var result = new Result<TimeTable>();
            var context = DbContext;
            try
            {
                if (string.IsNullOrEmpty(u.StartTime))
                {
                    result.HasError = true;
                    result.Message = "Invalid Start Time";
                    return result;
                }
                if (string.IsNullOrEmpty(u.EndTime))
                {
                    result.HasError = true;
                    result.Message = "Invalid End Time";
                    return result;
                }
                if (string.IsNullOrEmpty(u.RoomNum))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

               
                var objToSave = context.TimeTable.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {   
                    objToSave = new TimeTable();
                    context.TimeTable.Add(objToSave);

                   
                }

                objToSave.ClassName = u.ClassName;
                objToSave.SectionName = u.SectionName;
                objToSave.SubjectName = u.SubjectName;
                objToSave.WeekName = u.WeekName;
                objToSave.StartTime = u.StartTime;
                objToSave.EndTime = u.EndTime;
                objToSave.RoomNum = u.RoomNum;
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
                var timeTable = context.TimeTable.FirstOrDefault(ui => ui.ID == id);
                if (timeTable == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.TimeTable.Remove(timeTable);
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
