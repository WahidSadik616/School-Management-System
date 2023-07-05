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
    public class OtherUserClassController : BaseController
    {
        private MMSDbContext objSectionsDbContext;

        public OtherUserClassController()
        {
            
            objSectionsDbContext = new MMSDbContext();
           
        }

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
            var result = ClassSectionRepo.GetAll(key);

            return View(result);
        }
        public ActionResult Add()
        {
            try
            {
               
                ClassSectionModel objSectionsViewModel = new ClassSectionModel()
                {

                    ListOfClasses = (from objClass in objSectionsDbContext.Class
                                     where objClass.MadrasaId == HttpUtil.UserProfile.MadrasaID
                                     select new SelectListItem()
                                     {
                                         Text = objClass.Name,
                                         Value = objClass.ID.ToString()
                                     }).ToList(),
                    ListOfSections = (from objSection in objSectionsDbContext.Section
                                      where objSection.MadrasaId == HttpUtil.UserProfile.MadrasaID
                                      select new SectionsModel()
                                      {
                                          SectionId = objSection.ID,
                                          SectionName = objSection.Name,
                                          IsSelected = false
                                      }).ToList()
                };
                
               
                return View(objSectionsViewModel);
            }
            catch (Exception ex)
            {
                return null;
            }
           
               
            
           
            
        }

        [HttpPost]
        public JsonResult Add(int classId, List<int> listOfSectionId)
        {
            try
            {

                if (objSectionsDbContext.ClassSection.Any(m => m.ClassID == classId && HttpUtil.UserProfile.MadrasaID!=null))
                {
                    objSectionsDbContext.ClassSection.RemoveRange(objSectionsDbContext.ClassSection.Where(m => m.ClassID == classId));
                    objSectionsDbContext.SaveChanges();
                }
                
                var sectionList=objSectionsDbContext.Section.ToList();
                var classList = objSectionsDbContext.Class.ToList();
               
                foreach (var item in listOfSectionId)
                {
                    for (int i = 0; i < sectionList.Count; i++)
                    {
                        if(sectionList[i].ID==item)
                        {
                            ClassSection objClassSection = new ClassSection();
                            objClassSection.ClassID = classId;
                            objClassSection.SectionID = item;
                            objClassSection.SectionName = sectionList[i].Name;
                            for (int j = 0; j < classList.Count;j++ )
                            {
                                if(classList[j].ID==classId)
                                {
                                    objClassSection.ClassName = classList[j].Name;
                                }
                            }
                            objClassSection.MadrasaId = HttpUtil.UserProfile.MadrasaID;

                            
                            objSectionsDbContext.ClassSection.Add(objClassSection);
                        }    
                    }
                   
                    
                    objSectionsDbContext.SaveChanges();
                }
                int id=objSectionsDbContext.Class.First(m => m.MadrasaId == HttpUtil.UserProfile.MadrasaID).ID;
                
                return Json(new { success = true, message = "Data Successfully Added.", id }, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception)
            {
                return null;
            }
                    
        }

        public JsonResult GetAssignedSections(int classId)
        {
            return Json(new { 
                data = objSectionsDbContext.ClassSection.Where(m => m.ClassID == classId) 
              
            },
            JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult Delete(string secName, int classId)
        {
            var result = ClassSectionRepo.Delete(secName,classId);


            if (result.HasError)
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("Index");

        }
       
       
	}
}