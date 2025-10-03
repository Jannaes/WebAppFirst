using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppFirst.Models
{
    public class Logins
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string LoginErrorMessage { get; internal set; }
    }
}