﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            List<User> ui = new List<User>();
            User u = new User();
            ui = u.GetUserInfo();
            return ui;
        }



        // POST api/<controller>
        public int Post([FromBody]User u)
        {
            return u.insertUser();
        }

        // PUT api/<controller>/5
        public int Put(int id, [FromBody]User u)
        {
            return u.UpdateUser();
        }

        [HttpPut]
        [Route("api/users/updateprofile")]
        public int post(int id, [FromBody]User u)
        {
            return u.UpdateProfileUser();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}