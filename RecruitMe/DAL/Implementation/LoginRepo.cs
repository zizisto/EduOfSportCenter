using RecruitMe.DAL.Interfaces;
using RecruitMe.Models;
using System;
using System.Collections.Generic;
using System.Components.Dapper;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RecruitMe.DAL.Implementation
{
    public class LoginRepo : DapperBase, ILoginRepo
    {
        private string ConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool Login(LoginDetailsModel logins)
        {
            var rows = ExecuteModel<int>("", logins, ConString);

            return (rows > 0) ? true : false;
        }
    }
}