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
        public int Post([FromBody]List<Answer> a)
        {
            Answer.list = a;
            Answer ans = new Answer();
            return ans.InsertAnswers();
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