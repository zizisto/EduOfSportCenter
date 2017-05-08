using RecruitMe.DAL.Interfaces;
using RecruitMe.Models;
using System;
using System.Collections.Generic;
using System.Components.Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RecruitMe.DAL.Implementation
{
    public class PlayerRepo : DapperBase, IPlayerRepo
    {
        private string ConString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public bool InsertPlayer(PlayerDetailsModel ourPlayer)
        {
            var rows = ExecuteModel<int>("InsertPlayer", new { ourPlayer }, ConString);

            return (rows > 0) ? true : false;
        }

        public bool DeletePlayer(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePlayer(PlayerDetailsModel ourPlayer)
        {
            throw new NotImplementedException();
        }
    }
}