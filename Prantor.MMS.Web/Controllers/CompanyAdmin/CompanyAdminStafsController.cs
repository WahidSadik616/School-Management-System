using Newtonsoft.Json;
using Prantor.MMS.Entities;
using Prantor.MMS.Framework;
using Prantor.MMS.Web.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prantor.MMS.Web.Controllers
{
    public class CompanyAdminStafsController : BaseController
    {

        public ActionResult Index()
        {
            return Content("Stafs Information View");
        }


    }
}