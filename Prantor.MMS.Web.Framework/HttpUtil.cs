using Newtonsoft.Json;
using Prantor.MMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Prantor.MMS.Web.Framework
{
    public class HttpUtil
    {
        public static UserProfile UserProfile
        {
            get
            {
                var sessionData = HttpContext.Current.User.Identity.Name;
                var up = JsonConvert.DeserializeObject<UserProfile>(sessionData);
                return up;
            }
        }
    }
}
