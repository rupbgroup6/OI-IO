using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Question
    {
        private int questionId;
        private string questionSTR;
        private string kindOfQuestion;
        private int orderView;
        private int orOrderView;

        public int QuestionId { get => questionId; set => questionId = value; }
        public string QuestionSTR { get => questionSTR; set => questionSTR = value; }
        public string KindOfQuestion { get => kindOfQuestion; set => kindOfQuestion = value; }
        public int OrderView { get => orderView; set => orderView = value; }
        public int OrOrderView { get => orOrderView; set => orOrderView = value; }

        public Question()
        {

        }

        public Question(int questionId, string question, string kindOfQuestion, int orderView, int orOrderView)
        {
            QuestionId = questionId;
            QuestionSTR = question;
            KindOfQuestion = kindOfQuestion;
            OrderView = orderView;
            OrOrderView = OrOrderView;
        }


        public List<Question> getQuestions()
        {
            List<Question> temp = new List<Question>();
            DBservices dbs = new DBservices();
            temp = dbs.getQuestions();
            return temp;
        }

        public int AddQuestion()
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.AddQuestion(this);
            return rowEffected;
        }

        public int ChangeQuestion()
        {
            DBservices dbs = new DBservices();
            int rawEffected = dbs.ChangeQuestion(this);
            return rawEffected;
        }

        public int deleteQuestion(int id)
        {
            DBservices dbs = new DBservices();
            int rowEffected = dbs.deleteQuestion(id);
            return rowEffected;
        }
    }
}