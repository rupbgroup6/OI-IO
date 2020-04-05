using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class QuestionsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Question> Get()
        {
            List<Question> ql = new List<Question>();
            Question q = new Question();
            ql = q.getQuestions();
            return ql;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post([FromBody]Question q)
        {
            return q.AddQuestion();
        }

        // PUT api/<controller>/5
        public int Put(int id, [FromBody]Question q)
        {
            return q.ChangeQuestion();
        }

        // DELETE api/<controller>/5
        public int Delete(int id)
        {
            Question q = new Question();
            return q.deleteQuestion(id);
        }
    }
}