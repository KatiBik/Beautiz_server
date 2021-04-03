using Beautiz_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beautiz_server.Controllers
{
    public class AppointmentController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(AppointmentDB.GetAllAppointment());
            }
            catch (Exception ex)
            {
                return BadRequest("could not get all the Appointment!");
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                List<Appointment> u = AppointmentDB.GetAppointmentByID(id);
                if (u != null)
                {
                    return Ok(u);
                }
                return Content(HttpStatusCode.NotFound, $"Appointment witn id {id} was not found!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Post([FromBody] Appointment Appointment2Insert)
        {
            try
            {
                int res = AppointmentDB.InsertAppointment(Appointment2Insert);
                if (res == -1)
                {
                    return Content(HttpStatusCode.BadRequest, $"user with id = {Appointment2Insert.appointmentID} was not created in DB!!!");
                }
                Appointment2Insert.appointmentID = res;
                return Created(new Uri(Request.RequestUri.AbsoluteUri + res), Appointment2Insert);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
