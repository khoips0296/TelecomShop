using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Common
{
    [Serializable]
    public class MemberLogin
    {
        public long MemberID { set; get; }
        public string MemberName { set; get; }
        public string GroupID { set; get; }
    }
}