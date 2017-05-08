using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitMe.Models
{
    public class LoginDetailsModel
    {
        public int PlayerId { get; set; }
        public string EmailAddress { get; set; }
        public List<string> Type { get; set; }
        public string Password { get; set; }
    }
}