﻿using Newtonsoft.Json;
using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Prantor.MMS.Web.Controllers
{
    [MMSAuthorize(new[] { (int)EnumCollection.UserTypeEnum.MadrasaMember })]
    public class MadrasaMemberController : BaseController
    {
        //
        // GET: /CompanyAdmin/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profile()
        {
            var user = UserInfoRepo.GetByID(HttpUtil.UserProfile.ID).Data;
            return View(user);
        }
        [HttpPost]
        public ActionResult Profile(UserInfo model)
        {

            if (!ModelState.IsValid)
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
                UserTypeId = (int)EnumCollection.UserTypeEnum.MadrasaMember,
                Email = model.Email

            };
            model.UserTypeId = 3;
            var result = UserInfoRepo.SaveChangeProfile(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
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
                UserTypeID = (int)EnumCollection.UserTypeEnum.MadrasaMember,
                GenderID = result.Data.GenderId,
                BloodGroupId = result.Data.BloodGroupId,
                StatusId = (int)EnumCollection.UserStatusEnum.Active,
                MadrasaID = result.Data.MadrasaId,
                Madrasa = Madrasa.Data.Name
            };

            var sessionData = JsonConvert.SerializeObject(up);

            FormsAuthentication.SetAuthCookie(sessionData, false);
            return RedirectToAction("Index");

        }
        public ActionResult MadrasaDetails(int id)
        {
            var MadrasaInfo =MadrasaRepo.GetByID(id).Data;
            return View(MadrasaInfo);
        }

        
        public ActionResult Apply(int id, int madrasaId)
        {
            var User = UserInfoRepo.GetByID(id).Data;
            ViewBag.Error = TempData["Error"];
            User.MadrasaId = madrasaId;
            User.UserTypeId = (int)Prantor.MMS.Framework.EnumCollection.UserTypeEnum.OtherUsers;
            User.StatusId = (int)Prantor.MMS.Framework.EnumCollection.UserStatusEnum.Pending;
            var appliedUser=UserInfoRepo.Save(User);
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn","Home");
        }
	}
}