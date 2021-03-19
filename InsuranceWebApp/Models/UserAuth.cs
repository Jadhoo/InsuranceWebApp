using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceWebApp.Models
{
    public class UserAuth
    {
        public int UId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}