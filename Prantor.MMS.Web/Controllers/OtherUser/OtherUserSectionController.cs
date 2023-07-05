using Prantor.MMS.Entities;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Prantor.MMS.Web.Controllers
{
    public class OtherUserSectionController : BaseController
    {
        public ActionResult Index(string key = "")
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            else
            {
                ViewBag.Error = TempData["Error"];
            }
            var result = SectionRepo.GetAll(key);
            
            return View(result);
        }
        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var section = SectionRepo.GetByID(id).Data ?? new Section();
            return View(section);
        }
        [HttpPost]
        public ActionResult Add(Section model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var section = new Section()
            {
                Name = model.Name,
                MadrasaId = model.MadrasaId
            };
            var result = SectionRepo.Save(section);

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
            var section = SectionRepo.GetByID(id).Data ?? new Section();
            return View(section);
        }
        [HttpPost]
        public ActionResult Edit(Section model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = SectionRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = SectionRepo.Delete(id);
            

            if (result.HasError)
            {
               TempData["Error"] = result.Message;
            }
             return RedirectToAction("Index");
        
        }
	}
}