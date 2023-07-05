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
    public class OtherUserSubjectController : BaseController
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
            var result = SubjectRepo.GetAll(key);
            return View(result);
        }
        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var subject = SubjectRepo.GetByID(id).Data ?? new Subject();
            return View(subject);
        }
        [HttpPost]
        public ActionResult Add(Subject model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var subject = new Subject()
            {
                Name = model.Name,
                SubjectCode=model.SubjectCode,
                SubjectType=model.SubjectType,
                MadrasaId = model.MadrasaId
            };
            var result = SubjectRepo.Save(subject);

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
            var subject = SubjectRepo.GetByID(id).Data ?? new Subject();
            return View(subject);
        }
        [HttpPost]
        public ActionResult Edit(Subject model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = SubjectRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = SubjectRepo.Delete(id);

            if (result.HasError)
            {
               TempData["Error"] = result.Message;
            }
             return RedirectToAction("Index");
        
        }
	}
}