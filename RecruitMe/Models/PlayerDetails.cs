using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitMe.Models
{
    public class PlayerDetailsModel
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Gender { get; set; }
        public string SchoolLevel { get; set; }
        public string ParentFistname { get; set; }
        public string ParentLastname { get; set; }
        public List<string> Sport { get; set; }        
        //public string ParentEmailAddress { get; set; }
        //public string ParentPassword { get; set; }
    }
}