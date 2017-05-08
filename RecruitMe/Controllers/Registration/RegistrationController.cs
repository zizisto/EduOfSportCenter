using RecruitMe.DAL.Implementation;
using RecruitMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RecruitMe.Controllers
{
    public class RegistrationController : ApiController
    {
        private PlayerRepo _playerRepo = new PlayerRepo();

        public HttpResponseMessage RegisterPlayer([FromBody] PlayerDetailsModel details)
        {
          bool bRes = _playerRepo.InsertPlayer(details);

            HttpResponseMessage response = ((bRes) ? Request.CreateResponse(HttpStatusCode.OK, "Details have been entered correctly.")
                : Request.CreateResponse(HttpStatusCode.BadRequest, "Error when inserting."));

            return response;
        }
    }
}
