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
    public class OtherUserTimeTableController : BaseController
    {
        public ActionResult Index()
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            else
            {
                ViewBag.Error = TempData["Error"];
            }
            var result = TimeTableRepo.GetAll();
            
            return View(result);
        }
        public ActionResult Add(int id)
        {
            if (HttpUtil.UserProfile == null)
            {
                ViewBag.Error = "Session TimeOut";
            }
            var timeTable = TimeTableRepo.GetByID(id).Data ?? new TimeTable();
            return View(timeTable);
        }
        [HttpPost]
        public ActionResult Add(TimeTable model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var timeTable = new TimeTable()
            {
                ClassName=model.ClassName,
                SectionName = model.SectionName,
                SubjectName = model.SubjectName,
                WeekName = model.WeekName,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                RoomNum = model.RoomNum,
                MadrasaId = model.MadrasaId
            };
            var result = TimeTableRepo.Save(timeTable);

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
            var timeTable = TimeTableRepo.GetByID(id).Data ?? new TimeTable();
            return View(timeTable);
        }
        [HttpPost]
        public ActionResult Edit(TimeTable model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = TimeTableRepo.Save(model);

            if (result.HasError)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var result = TimeTableRepo.Delete(id);
            

            if (result.HasError)
            {
               TempData["Error"] = result.Message;
            }
             return RedirectToAction("Index");
        
        }
	}
}