using Beautiz_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beautiz_server.Controllers
{
    public class TreatmentController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(TreatmentDB.GetAllTreatment());
            }
            catch (Exception ex)
            {
                return BadRequest("could not get all the Treatment!");
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Treatment> u = TreatmentDB.GetTreatmentByID(id);
                if (u != null)
                {
                    return Ok(u);
                }
                return Content(HttpStatusCode.NotFound, $"Treatment witn id {id} was not found!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody] Treatment treatment2Insert)
        {
            try
            {
                int res = TreatmentDB.InsertTreatment(treatment2Insert);
                if (res == -1)
                {
                    return Content(HttpStatusCode.BadRequest, $"Treatment with id = {treatment2Insert.treatmentId} was not created in DB!!!");
                }
                treatment2Insert.treatmentId= res;
                return Created(new Uri(Request.RequestUri.AbsoluteUri + res), treatment2Insert);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
