using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecomShop.Common
{
    [Serializable]
    public class EmployeeLogin
    {
        public long EmployeeID { set; get; }
        public string EmployeeName { set; get; }
        public string GroupID { set; get; }
    }
}