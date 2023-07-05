using Prantor.MMS.Data;
using Prantor.MMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Prantor.MMS.Web.Controllers.api
{
    public class UserInfo2Controller : ApiController
    {
        private MMSDbContext _context;

        public UserInfo2Controller()
        {
            _context = new MMSDbContext();
        }
        [HttpGet]
        public List<UserInfo> GetAll(string key="")
        {
            IQueryable<UserInfo> query = _context.UserInfos;

            if(!string.IsNullOrEmpty(key) && !string.IsNullOrWhiteSpace(key))
            {
                query = query.Where(q => q.Name.Contains(key));
            }
            return query.ToList();
        }

        [HttpGet]
        public UserInfo GetByID(int id)
        {
           
            return _context.UserInfos.FirstOrDefault(e=>e.ID==id);
        } 
 
        [HttpPost]
        public UserInfo Save(UserInfo user)
        {
            try
            {
                var objToSave = _context.UserInfos.FirstOrDefault(m => m.ID == user.ID);
                if (objToSave == null)
                {
                    objToSave = new UserInfo();
                    _context.UserInfos.Add(objToSave);
                }

                objToSave.Name = user.Name;
                objToSave.UserName = user.UserName;
                objToSave.Password = user.Password;
                objToSave.PhoneNo = user.PhoneNo;
                objToSave.Address = user.Address;
                objToSave.DateOfBirth = user.DateOfBirth;
                objToSave.UserTypeId = user.UserTypeId;
                objToSave.GenderId = user.GenderId;
                objToSave.BloodGroupId = user.BloodGroupId;
                objToSave.StatusId = user.StatusId;
                objToSave.Email = user.Email;
                objToSave.MadrasaId = user.MadrasaId;

                _context.SaveChanges();

                return objToSave;
               
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpDelete]
        public UserInfo Delete(int id)
        {
            try
            {
                var objToSave = _context.UserInfos.FirstOrDefault(m => m.ID == id);
                if (objToSave == null)
                {
                    return null;
                }

                _context.UserInfos.Remove(objToSave);

                _context.SaveChanges();

                return objToSave;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
