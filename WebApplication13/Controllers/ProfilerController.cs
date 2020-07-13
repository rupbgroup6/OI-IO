using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;


namespace WebApplication13.Controllers
{
    public class ProfilerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Profiler> Get()
        {
            List<Profiler> pr = new List<Profiler>();
            Profiler p = new Profiler();
            pr = p.GetAllProfiles();
            return pr;
        }
        public IEnumerable<Profiler> Get(DateTime s, DateTime e)
        {
            List<Profiler> pr = new List<Profiler>();
            Profiler p = new Profiler();
            pr = p.GetAllProfilesByDate(s, e);
            return pr;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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