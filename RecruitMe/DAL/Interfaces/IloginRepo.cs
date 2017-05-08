using RecruitMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitMe.DAL.Interfaces
{
    public interface ILoginRepo
    {
        bool Login(LoginDetailsModel logins);
    }
}
