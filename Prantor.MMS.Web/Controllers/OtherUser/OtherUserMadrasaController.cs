using Newtonsoft.Json;
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
    public class OtherUserMadrasaController : BaseController
    {
        
        public ActionResult Edit(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var madrasa = MadrasaRepo.GetByID(id).Data ?? new Madrasa();
            return View(madrasa);
        }
        [HttpPost]
        public ActionResult Edit(Madrasa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           
            var result = MadrasaRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            var up = new UserProfile()
            {
                ID = HttpUtil.UserProfile.ID,
                Name = HttpUtil.UserProfile.Name,
                UserName = HttpUtil.UserProfile.UserName,
                Password = HttpUtil.UserProfile.Password,
                PhoneNo = HttpUtil.UserProfile.PhoneNo,
                Address = HttpUtil.UserProfile.Address,
                Email = HttpUtil.UserProfile.Email,
                DateOfBirth = HttpUtil.UserProfile.DateOfBirth,
                UserTypeID = HttpUtil.UserProfile.UserTypeID,
                GenderID = HttpUtil.UserProfile.GenderID,
                BloodGroupId = HttpUtil.UserProfile.BloodGroupId,
                StatusId = HttpUtil.UserProfile.StatusId,
                Madrasa = result.Data.Name,
                MadrasaID = HttpUtil.UserProfile.MadrasaID
               
            };

            var sessionData = JsonConvert.SerializeObject(up);

            FormsAuthentication.SetAuthCookie(sessionData, false);
            return Redirect(Request.UrlReferrer.AbsolutePath.ToString());
        }
        
	}
}