using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class StudentRepo : BaseRepo
    {
        public Result<List<Student>> GetAll(string key="")
        {
            var result = new Result<List<Student>>();
            var context = DbContext;
            try {

                var students = context.Students.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    students = students.Where(u => u.Name.ToUpper().Contains(key.ToUpper()) ||
                        u.FatherName.ToUpper().Contains(key.ToUpper()) ||
                        u.MotherName.ToUpper().Contains(key.ToUpper()) ||
                        u.PhoneNo.ToUpper().Contains(key.ToUpper()) ||
                        u.Address.ToUpper().Contains(key.ToUpper())).ToList();
                }

                result.Data = students;
            }
            catch(Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Student> GetByID(int id)
        {
            var result = new Result<Student>();
            var context = DbContext;
            try
            {
                result.Data = context.Students.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<Student> Save(Student u)
        {
            
            var result = new Result<Student>();
            var context = DbContext;
            try
            {
                var objToSave = context.Students.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {   
                    objToSave = new Student();
                    context.Students.Add(objToSave);
                }


                if(string.IsNullOrEmpty(u.Name))
                {
                   result.HasError = true;
                   result.Message = "Invalid Name";
                   return result;
                }

                if (string.IsNullOrEmpty(u.FatherName))
                {
                    result.HasError = true;
                    result.Message = "Invalid Father Name";
                    return result;
                }

                if (string.IsNullOrEmpty(u.FatherNid))
                {
                    result.HasError = true;
                    result.Message = "Invalid Father Nid";
                    return result;
                }

                if (string.IsNullOrEmpty(u.MotherName))
                {
                    result.HasError = true;
                    result.Message = "Invalid Mother Name";
                    return result;
                }

                if (string.IsNullOrEmpty(u.MotherNid))
                {
                    result.HasError = true;
                    result.Message = "Invalid Mother Nid";
                    return result;
                }

                if (string.IsNullOrEmpty(u.PhoneNo))
                {
                    result.HasError = true;
                    result.Message = "Invalid Phone No.";
                    return result;
                }

                if (string.IsNullOrEmpty(u.Address))
                {
                    result.HasError = true;
                    result.Message = "Invalid Address";
                    return result;
                }


               
                objToSave.Name = u.Name;
                objToSave.FatherName = u.FatherName;
                objToSave.FatherNid = u.FatherNid;
                objToSave.MotherName = u.MotherName;
                objToSave.MotherNid = u.MotherNid;
                objToSave.PhoneNo = u.PhoneNo;
                objToSave.Address = u.Address;
                objToSave.Email = u.Email;
                objToSave.DateOfBirth = u.DateOfBirth;
                objToSave.GenderId = u.GenderId;
                objToSave.BloodGroupId = u.BloodGroupId;       
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
                var student = context.Students.FirstOrDefault(ui => ui.ID == id);
                if (student == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }             

                context.Students.Remove(student);
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
