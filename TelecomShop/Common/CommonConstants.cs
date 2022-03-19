using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartProductSession = "CartProductSession";
        public static string CartPackSession = "CartPackSession";
        public static string MEMBER_SESSION = "MEMBER_SESSION";

        public static string CurrentCulture { set; get; }
    }
}