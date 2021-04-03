using Beautiz_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beautiz_server.Controllers
{
    public class typeOfTreatController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(typeOfTreatDB.GetAlltypeOfTreat());
            }
            catch (Exception ex)
            {
                return BadRequest("could not get all the typeOfTreat!");
            }
        }
    }
}
