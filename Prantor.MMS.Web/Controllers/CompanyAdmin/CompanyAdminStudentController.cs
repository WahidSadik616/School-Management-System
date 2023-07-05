using Prantor.MMS.Entities;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Controllers
{
    public class CompanyAdminStudentController : BaseController
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
            var result = StudentRepo.GetAll(key);
            return View(result);
        }
        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var student = StudentRepo.GetByID(id).Data ?? new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Add(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var student = new Student()
            {
                Name = model.Name,
                FatherName = model.FatherName,
                FatherNid = model.FatherNid,
                MotherNid = model.MotherNid,
                MotherName = model.MotherName,
                PhoneNo = model.PhoneNo,
                Address = model.Address,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth.ToString(),
                GenderId = model.GenderId,
                BloodGroupId = model.BloodGroupId,
                MadrasaId = model.MadrasaId
            };
            var result = StudentRepo.Save(student);

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
            var student = StudentRepo.GetByID(id).Data ?? new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = StudentRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = StudentRepo.Delete(id);

            if (result.HasError)
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("Index");
        }
	}
}