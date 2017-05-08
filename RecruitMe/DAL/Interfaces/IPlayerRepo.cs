using RecruitMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitMe.DAL.Interfaces
{
    internal interface IPlayerRepo
    {
        bool InsertPlayer(PlayerDetailsModel ourPlayer);

        bool DeletePlayer(int playerId);

        bool UpdatePlayer(PlayerDetailsModel ourPlayer);

    }
}
