using Prantor.MMS.Entities;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Controllers
{
    public class SuperAdminMadrasaController : BaseController
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
            var result = MadrasaRepo.GetAll(key);
            return View(result);
        }


        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }  
            var user = MadrasaRepo.GetByID(id).Data ?? new Madrasa();
            return View(user);
        }

        [HttpPost]
        public ActionResult Add(Madrasa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var madrasa = new Madrasa()
            {
                Name = model.Name,
                Address=model.Address,
                DirectorName=model.DirectorName,
                ContactNo=model.ContactNo
            };
            var result = MadrasaRepo.Save(madrasa);

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
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var result = MadrasaRepo.Delete(id);

            if (result.HasError)
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("Index");
        }
	}
}