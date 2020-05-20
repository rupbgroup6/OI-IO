using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class OrQuestion : Question
    {

        private int orOrderView;

        public OrQuestion()
        {

        }

        public OrQuestion(int questionId, string question, string kindOfQuestion, int orderView, int orOrderView) : base(questionId, question, kindOfQuestion,orderView)
        {
            OrOrderView = orOrderView;
        }

        public int OrOrderView { get => orOrderView; set => orOrderView = value; }
    }
}