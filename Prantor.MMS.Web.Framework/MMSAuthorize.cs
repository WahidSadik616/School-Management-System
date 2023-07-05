using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prantor.MMS.Web.Framework
{
    [AttributeUsage(AttributeTargets.Method|AttributeTargets.Class,AllowMultiple=true,Inherited=true)]
    public class MMSAuthorize: FilterAttribute,IAuthorizationFilter
    {
        public int[] Type { get; set; }

        public MMSAuthorize(int[] type)
        {
            Type = type;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(HttpUtil.UserProfile==null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                return;
            }

            if (this.Type.Contains(HttpUtil.UserProfile.UserTypeID))
                return;
            if(HttpUtil.UserProfile.UserTypeID==(int)EnumCollection.UserTypeEnum.SuperAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            action="Index",
                            controller="SuperAdmin"
                        }
                        )
                    );
                return;
            }

            if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.Admin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            action = "Index",
                            controller = "Admin"
                        }
                        )
                    );
                return;
            }

            if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.OtherUsers)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            action = "Index",
                            controller = "OtherUsers"
                        }
                        )
                    );
                return;
            }

            if (HttpUtil.UserProfile.UserTypeID == (int)EnumCollection.UserTypeEnum.MadrasaMember)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            action = "Index",
                            controller = "MadrasaMember"
                        }
                        )
                    );
                return;
            }
        }

        internal void OnAuthorizationHelp(AuthorizationContext filterContext)
        {

            if (filterContext.Result is HttpUnauthorizedResult)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.HttpContext.Response.End();
                }
            }
        }       
    }
}
