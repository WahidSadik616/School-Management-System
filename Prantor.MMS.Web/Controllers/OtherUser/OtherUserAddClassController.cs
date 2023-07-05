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
    public class OtherUserAddClassController : BaseController
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
            var result = ClassRepo.GetAll(key);
            return View(result);
        }
        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var _class = ClassRepo.GetByID(id).Data ?? new Class();
            return View(_class);
        }
        [HttpPost]
        public ActionResult Add(Class model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var _class = new Class()
            {
                Name = model.Name,
                MadrasaId = model.MadrasaId
            };
            var result = ClassRepo.Save(_class);

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
            var _class = ClassRepo.GetByID(id).Data ?? new Class();
            return View(_class);
        }
        [HttpPost]
        public ActionResult Edit(Class model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = ClassRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = ClassRepo.Delete(id);

            if (result.HasError)
            {
               TempData["Error"] = result.Message;
            }
             return RedirectToAction("Index");
        
        }
	}
}