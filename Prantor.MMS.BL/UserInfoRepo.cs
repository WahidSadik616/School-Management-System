using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prantor.MMS.BL
{
    public class UserInfoRepo : BaseRepo
    {
        public Result<List<UserInfo>> GetAll(string key="")
        {
            var result = new Result<List<UserInfo>>();
            var context = DbContext;
            try {

                var users = context.UserInfos.ToList();

                if (!string.IsNullOrEmpty(key))
                {
                    users = users.Where(u => u.Name.ToUpper().Contains(key.ToUpper()) ||
                        u.UserName.ToUpper().Contains(key.ToUpper()) ||
                        u.PhoneNo.ToUpper().Contains(key.ToUpper()) ||
                        u.Address.ToUpper().Contains(key.ToUpper())).ToList();
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

        public Result<UserInfo> GetByID(int id)
        {
            var result = new Result<UserInfo>();
            var context = DbContext;
            try
            {
                result.Data = context.UserInfos.FirstOrDefault(u => u.ID == id);
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<UserInfo> Save(UserInfo u)
        {
            
            var result = new Result<UserInfo>();
            var context = DbContext;
            try
            {
                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

                if (string.IsNullOrEmpty(u.UserName))
                {
                    result.HasError = true;
                    result.Message = "Invalid Username";
                    return result;
                }

                if (string.IsNullOrEmpty(u.Password))
                {
                    result.HasError = true;
                    result.Message = "Invalid Password";
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


                if (context.UserInfos.Any(ui => ui.PhoneNo == u.PhoneNo && ui.ID != u.ID))
                {
                    result.HasError = true;
                    result.Message = "Phone Number Already exist";

                    return result;
                }

                if (context.UserInfos.Any(ui => ui.Email == u.Email && ui.ID != u.ID && ui.Email != null))
                {
                    result.HasError = true;
                    result.Message = "Email Already exist";

                    return result;
                }

                var objToSave = context.UserInfos.FirstOrDefault(ui => ui.UserName == u.UserName);

                if (objToSave == null)
                {   
                    objToSave = new UserInfo();
                    context.UserInfos.Add(objToSave);

                   
                }    
               
                objToSave.Name = u.Name;
                objToSave.UserName = u.UserName;
                objToSave.Password = u.Password;
                objToSave.PhoneNo = u.PhoneNo;
                objToSave.Address = u.Address;
                objToSave.DateOfBirth = u.DateOfBirth;
                objToSave.UserTypeId = u.UserTypeId;
                objToSave.GenderId = u.GenderId;
                objToSave.BloodGroupId = u.BloodGroupId;
                objToSave.StatusId = u.StatusId;
                objToSave.Email = u.Email;
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
                var user = context.UserInfos.FirstOrDefault(ui => ui.ID == id);
                if (user == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid Id";
                    return result;
                }

                context.UserInfos.Remove(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }
            return result;
        }

        public Result<UserInfo> Register(UserInfo u)
        {
            var result = new Result<UserInfo>();
            var context = DbContext;
            try
            {
                
                var objToSave = context.UserInfos.FirstOrDefault(ui => ui.ID == u.ID);

                if (objToSave == null)
                {
                    objToSave = new UserInfo();
                    context.UserInfos.Add(objToSave);
                }

                if (context.UserInfos.Any(ui => ui.UserName == u.UserName))
                {
                    result.HasError = true;
                    result.Message = "UserName Already exist";

                    return result;
                }

                if (context.UserInfos.Any(ui => ui.PhoneNo == u.PhoneNo))
                {
                    result.HasError = true;
                    result.Message = "Phone Number Already exist";

                    return result;
                }

                if (context.UserInfos.Any(ui => ui.Email == u.Email && ui.Email != null))
                {
                    result.HasError = true;
                    result.Message = "Email Already exist";

                    return result;
                }

                objToSave.Name = u.Name;
                objToSave.UserName = u.UserName;
                objToSave.Password = u.Password;
                objToSave.PhoneNo = u.PhoneNo;
                objToSave.Address = u.Address;
                objToSave.DateOfBirth = u.DateOfBirth;
                objToSave.UserTypeId = (int)EnumCollection.UserTypeEnum.MadrasaMember;
                objToSave.GenderId = u.GenderId;
                objToSave.BloodGroupId = u.BloodGroupId;
                objToSave.StatusId = (int)EnumCollection.UserStatusEnum.Active;
                objToSave.Email = u.Email;
                objToSave.MadrasaId = 5;
       

                context.SaveChanges();

                result.Data = objToSave;

            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<UserInfo> Login(string userName, string password)
        {
            var result = new Result<UserInfo>();
            try
            {
                var context = DbContext;

                var validUser = 
                    context.UserInfos.FirstOrDefault(ui => ui.UserName == userName 
                                                     && ui.Password==password);
                
                if (validUser == null)
                {
                    result.HasError = true;
                    result.Message = "Invalid UserName or Password!";
                    return result;
                }

                if(validUser.StatusId==(int)EnumCollection.UserStatusEnum.Inactive)
                {
                    result.HasError = true;
                    result.Message = "Inactive user is not allowed to login!";
                    return result;
                }

                if (validUser.StatusId == (int)EnumCollection.UserStatusEnum.Pending)
                {
                    result.HasError = true;
                    result.Message = "Pending user is not allowed to login!";
                    return result;
                }


                result.Data = validUser;
            }
            catch (Exception ex)
            {
                result.HasError = true;
                result.Message = ex.Message;
            }

            return result;
        }

        public Result<UserInfo> SaveChangeProfile(UserInfo u)
        {

            var result = new Result<UserInfo>();
            var context = DbContext;
            try
            {
                if (context.UserInfos.Any(ui => ui.UserName ==u.UserName && ui.ID!=u.ID))
                {
                    result.HasError = true;
                    result.Message = "User Name Already Exist!";

                    return result;
                }
   

                if (string.IsNullOrEmpty(u.Name))
                {
                    result.HasError = true;
                    result.Message = "Invalid Name";
                    return result;
                }

                if (string.IsNullOrEmpty(u.UserName))
                {
                    result.HasError = true;
                    result.Message = "Invalid Username";
                    return result;
                }

                if (string.IsNullOrEmpty(u.Password))
                {
                    result.HasError = true;
                    result.Message = "Invalid Password";
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

                var objToSave = context.UserInfos.FirstOrDefault(ui => ui.ID == u.ID);
                var madrasa = context.Madrasas.FirstOrDefault(m => m.ID == objToSave.MadrasaId);

                objToSave.Name = u.Name;
                objToSave.UserName = u.UserName;
                objToSave.Password = u.Password;
                objToSave.PhoneNo = u.PhoneNo;
                objToSave.Address = u.Address;
                objToSave.DateOfBirth = u.DateOfBirth;
                objToSave.UserTypeId = u.UserTypeId;
                objToSave.GenderId = u.GenderId;
                objToSave.BloodGroupId = u.BloodGroupId;
                objToSave.StatusId = u.StatusId;
                objToSave.Email = u.Email;
                objToSave.MadrasaId = madrasa.ID;

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
    }
}
