using Beautiz_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beautiz_server.Controllers
{
    public class BussinessController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(BussinessDB.GetAllBussiness());
            }
            catch (Exception ex)
            {
                return BadRequest("could not get all the bussiness!");
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Bussiness u = BussinessDB.GetBussinessByID(id);
                if (u != null)
                {
                    return Ok(u);
                }
                return Content(HttpStatusCode.NotFound, $"bussiness witn id {id} was not found!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IHttpActionResult Post([FromBody] Bussiness bussiness2Insert)
        {
            try
            {
                User u = UsersDB.GetUserByEmail(bussiness2Insert.userEmail);
                if (u != null)
                {
                    int res = BussinessDB.InsertBussiness(bussiness2Insert);
                    if (res == -1)
                    {
                        return Content(HttpStatusCode.BadRequest, $"bussiness with id = {bussiness2Insert.Bussiness_Id} was not created in DB!!!");
                    }
                    bussiness2Insert.Bussiness_Id = res;
                    return Created(new Uri(Request.RequestUri.AbsoluteUri + res), bussiness2Insert);
                }
                return Content(HttpStatusCode.BadRequest, $"user not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] Bussiness bussiness2Update)
        {
            try
            {
                Bussiness u = BussinessDB.GetBussinessByID(bussiness2Update.Bussiness_Id);
                if (u != null)
                {
                    int res = BussinessDB.UpdateBussiness(bussiness2Update);
                    if (res == 1)
                    {
                        return Ok($"bussiness with id = {bussiness2Update.Bussiness_Id} updated");
                    }
                    return Content(HttpStatusCode.NotModified, $"bussiness with id = {bussiness2Update.Bussiness_Id} exsits but could not be modified!!!");
                }
                return Content(HttpStatusCode.NotFound, $"bussiness with id = {bussiness2Update.Bussiness_Id} was not found to update!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
