using Newtonsoft.Json;
using Prantor.MMS.Data;
using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using Prantor.MMS.Model;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Prantor.MMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {

            RegistrationModel model = new RegistrationModel() { 
                BloodGroupId=-1,
                GenderId=-1,
                DateOfBirth=DateTime.Now
            };
            return View(model);
        }

        
        public ActionResult LogIn()
        {
            if(HttpUtil.UserProfile!=null)
            {
                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.SuperAdmin)
                {
                    
                    return RedirectToAction("Index","SuperAdmin");
                }

                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.Admin)
                {
                    return RedirectToAction("Index", "CompanyAdmin");
                }

                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.OtherUsers)
                {
                    return RedirectToAction("Index", "OtherUsers");
                }
                if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.MadrasaMember)
                {
                    return RedirectToAction("Index", "MadrasaMember");
                }
            }
            var model = new LogInModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = UserInfoRepo.Login(model.UserName, model.Password);
            if (result.HasError)
            {
                ViewBag.Message = result.Message;
                return View(model);
            }
            var Madrasa = MadrasaRepo.GetByID(result.Data.MadrasaId);
            if (Madrasa.HasError)
            {
                ViewBag.Message = Madrasa.Message;
                return View(model);
            }
            
            var up = new UserProfile()
            {
                ID = result.Data.ID,
                Name = result.Data.Name,
                UserName = result.Data.UserName,
                Password=result.Data.Password,
                PhoneNo=result.Data.PhoneNo,
                Address=result.Data.Address,
                Email=result.Data.Email,
                DateOfBirth=result.Data.DateOfBirth,
                UserTypeID = result.Data.UserTypeId,
                GenderID=result.Data.GenderId,
                BloodGroupId=result.Data.BloodGroupId,
                StatusId=result.Data.StatusId,
                MadrasaID=result.Data.MadrasaId,
                Madrasa=Madrasa.Data.Name
            };

            var sessionData = JsonConvert.SerializeObject(up);

            FormsAuthentication.SetAuthCookie(sessionData, false);

           if(result.Data.UserTypeId==(int)EnumCollection.UserTypeEnum.SuperAdmin)
            {
                return RedirectToAction("Index", "SuperAdmin");
            }
            else if(result.Data.UserTypeId == (int)EnumCollection.UserTypeEnum.Admin)
            {
                return RedirectToAction("Index", "CompanyAdmin");
            }
           else if (result.Data.UserTypeId == (int)EnumCollection.UserTypeEnum.MadrasaMember)
           {
               return RedirectToAction("Index", "MadrasaMember");
           }
            else
            {
                return RedirectToAction("Index", "OtherUsers");
            }
                
            
            
        }

        [HttpPost]
        public ActionResult SignUp(RegistrationModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

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
                Email=model.Email
               
            };

            var result = UserInfoRepo.Register(userInfo);

            if(result.HasError)
            {
                ViewBag.Message = result.Message;
                return View(model);
            }

            var Madrasa = MadrasaRepo.GetByID(result.Data.MadrasaId);
            if (Madrasa.HasError)
            {
                ViewBag.Message = Madrasa.Message;
                return View(model);
            }

            var up = new UserProfile()
            {
                ID = result.Data.ID,
                Name = result.Data.Name,
                UserName = result.Data.UserName,
                Password = result.Data.Password,
                PhoneNo = result.Data.PhoneNo,
                Address = result.Data.Address,
                Email = result.Data.Email,
                DateOfBirth = result.Data.DateOfBirth,
                UserTypeID = result.Data.UserTypeId,
                GenderID = result.Data.GenderId,
                BloodGroupId = result.Data.BloodGroupId,
                StatusId = result.Data.StatusId,
                MadrasaID = result.Data.MadrasaId,
                Madrasa = Madrasa.Data.Name
            };

            var sessionData = JsonConvert.SerializeObject(up);

            FormsAuthentication.SetAuthCookie(sessionData, false);
            
            
            return RedirectToAction("Index", "MadrasaMember");
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

    }
}