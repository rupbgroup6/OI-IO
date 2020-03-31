using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class AnswersController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Answer> Get(int id)
        {
            List<Answer> al = new List<Answer>();
            Answer a = new Answer();
            al = a.getUserAnswers(id);
            return al;
        }

        // POST api/<controller>
        public int Post([FromBody]Answer a)
        {
            return a.InsertAnswer();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}