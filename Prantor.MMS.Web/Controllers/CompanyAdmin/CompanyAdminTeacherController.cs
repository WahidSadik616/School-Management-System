﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Controllers
{
    public class CompanyAdminTeacherController : Controller
    {
        //
        // GET: /SuperAdminUserInfo/
        public ActionResult Index()
        {
            return Content("Teachers Information View");
        }
	}
}