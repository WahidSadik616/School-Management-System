using Newtonsoft.Json;
using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Controllers
{
    public class CompanyAdminUserInfoController : BaseController
    {
        
        public ActionResult Index(string key = "")
        {
            if(HttpUtil.UserProfile==null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            else
            {
                ViewBag.Error = TempData["Error"];
            }
            var result = UserInfoRepo.GetAll(key);  
            return View(result);
        }


        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";               
            }            
            var user = UserInfoRepo.GetByID(id).Data ?? new UserInfo();
            return View(user);
            
        }

        [HttpPost]
        public ActionResult Add(UserInfo model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          //  var sessionData = User.Identity.Name;
          //  var up = JsonConvert.DeserializeObject<UserProfile>(sessionData);
            var userInfo = new UserInfo()
            {
                Name = model.Name,
                UserName = model.UserName,
                Password = model.Password,
                PhoneNo = model.PhoneNo,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth.ToString(),
                BloodGroupId = model.BloodGroupId,
                GenderId = model.GenderId,
                StatusId = (int)EnumCollection.UserStatusEnum.Active,
                UserTypeId = (int)EnumCollection.UserTypeEnum.OtherUsers,
                Email = model.Email,
                MadrasaId=model.MadrasaId
            };
            var result = UserInfoRepo.Save(userInfo);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var user = UserInfoRepo.GetByID(id).Data ?? new UserInfo();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserInfo model)
        {
           if(!ModelState.IsValid)
           {
               return View(model);
           }
           var result = UserInfoRepo.Save(model);

           if(result.HasError)
           {
               ViewBag.Error = result.Message;
               return View(model);
           }
           return RedirectToAction("Index");
        }
       

        public ActionResult Delete(int id)
        {
            var result = UserInfoRepo.Delete(id);

            if(result.HasError)
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("Index");
        }
	}
}