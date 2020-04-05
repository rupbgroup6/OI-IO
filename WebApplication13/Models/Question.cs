using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication13.Models.DAL;

namespace WebApplication13.Models
{
    public class Question
    {
        int questionId;
        string questionSTR;
        string kindOfQuestion;
        int orderView;

        public int QuestionId { get => questionId; set => questionId = value; }
        public string QuestionSTR { get => questionSTR; set => questionSTR = value; }
        public string KindOfQuestion { get => kindOfQuestion; set => kindOfQuestion = value; }
        public int OrderView { get => orderView; set => orderView = value; }

        public Question()
        {

        }

        public Question(int questionId, string question, string kindOfQuestion, int orderView)
        {
            QuestionId = questionId;
            QuestionSTR = question;
            KindOfQuestion = kindOfQuestion;
            OrderView = orderView;
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