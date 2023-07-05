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
    public class OtherUserClassSectionSubjectController : BaseController
    {
        private MMSDbContext objSectionsSubjectDbContext;

        public OtherUserClassSectionSubjectController()
        {

            objSectionsSubjectDbContext = new MMSDbContext();
           
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
            var result = ClassSectionSubjectRepo.GetAll(key);

            return View(result);
        }
        public ActionResult Add()
        {
            try
            {

                ClassSectionSubjectModel objSectionsViewModel = new ClassSectionSubjectModel()
                {

                    ListOfClasses = (from objClass in objSectionsSubjectDbContext.Class
                                     where objClass.MadrasaId == HttpUtil.UserProfile.MadrasaID
                                     select new SelectListItem()
                                     {
                                         Text = objClass.Name,
                                         Value = objClass.ID.ToString()
                                     }).ToList(),
                    ListOfSections = (from objClass in objSectionsSubjectDbContext.Section
                                     where objClass.MadrasaId == HttpUtil.UserProfile.MadrasaID
                                     select new SelectListItem()
                                     {
                                         Text = objClass.Name,
                                         Value = objClass.ID.ToString()
                                     }).ToList(),
                    ListOfSubjects = (from objSubject in objSectionsSubjectDbContext.Subject
                                      where objSubject.MadrasaId == HttpUtil.UserProfile.MadrasaID
                                      select new SubjectModel()
                                      {
                                          SubjectId = objSubject.ID,
                                          SubjectName = objSubject.Name,
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
        public JsonResult Add(int classId, int sectionId, List<int> listOfSubjectId)
        {
            try
            {


                if (objSectionsSubjectDbContext.ClassSectionSubject.Any(m => m.SectionID == sectionId && m.ClassID==classId && HttpUtil.UserProfile.MadrasaID != null))
                {
                    objSectionsSubjectDbContext.ClassSectionSubject.RemoveRange(objSectionsSubjectDbContext.ClassSectionSubject.Where(m => m.SectionID == sectionId && m.ClassID==classId));
                    objSectionsSubjectDbContext.SaveChanges();
                }

                var subjectList = objSectionsSubjectDbContext.Subject.ToList();
                var classList = objSectionsSubjectDbContext.Class.ToList();
                var sectionList = objSectionsSubjectDbContext.Section.ToList();

                foreach (var item in listOfSubjectId)
                {
                    for (int i = 0; i < subjectList.Count; i++)
                    {
                        if (subjectList[i].ID == item)
                        {
                            ClassSectionSubject objClassSectionSubject = new ClassSectionSubject();
                            objClassSectionSubject.ClassID = classId;
                            objClassSectionSubject.SectionID = sectionId;
                            objClassSectionSubject.SubjectID = item;
                            objClassSectionSubject.SubjectName = subjectList[i].Name;
                            for (int j = 0; j < sectionList.Count; j++)
                            {
                                if (sectionList[j].ID == sectionId)
                                {
                                    objClassSectionSubject.SectionName = sectionList[j].Name;
                                }
                            }
                            for (int j = 0; j < classList.Count; j++)
                            {
                                if (classList[j].ID == classId)
                                {
                                    objClassSectionSubject.ClassName = classList[j].Name;
                                }
                            }

                            
                            objClassSectionSubject.MadrasaId = HttpUtil.UserProfile.MadrasaID;


                            objSectionsSubjectDbContext.ClassSectionSubject.Add(objClassSectionSubject);
                        }
                    }


                    objSectionsSubjectDbContext.SaveChanges();
                }
                int id = objSectionsSubjectDbContext.Class.First(m => m.MadrasaId == HttpUtil.UserProfile.MadrasaID).ID;

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
                data = objSectionsSubjectDbContext.ClassSection.Where(m => m.ClassID == classId) 
              
            },
            JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetAssignedSubjects(int classId, int sectionId)
        {
            return Json(new
            {
                data = objSectionsSubjectDbContext.ClassSectionSubject.Where(m => m.SectionID == sectionId && m.ClassID==classId)

            },
            JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(string subName, int secId)
        {
            var result = ClassSectionSubjectRepo.Delete(subName, secId);


            if (result.HasError)
            {
                TempData["Error"] = result.Message;
            }
            return RedirectToAction("Index");

        }
       
       
	}
}