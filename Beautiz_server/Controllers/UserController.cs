using Beautiz_server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Beautiz_server.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(UsersDB.GetAllUsers());
            }
            catch (Exception ex)
            {
                return BadRequest("could not get all the users!\n" + ex.Message);
            }
        }
        public IHttpActionResult Post([FromBody] User user2Insert)
        {
            try
            {
                User checkIfUserExist = UsersDB.GetUserByEmail(user2Insert.email);
                if (checkIfUserExist == null)
                {
                    int res = UsersDB.InsertUser(user2Insert);
                    if (res == 0)
                    {
                        return Content(HttpStatusCode.BadRequest, $"user with id = {user2Insert.email} was not created in DB!!!");
                    }
                    return Created(new Uri(Request.RequestUri.AbsoluteUri + res), user2Insert);
                }
                return Content(HttpStatusCode.BadRequest, $"user exist in DB!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
