using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal class Answer
    {
        public Answer(int answerId, string answerTxt)
        {
            AnswerId = answerId;
            AnswerTxt = answerTxt;
        }

        public int AnswerId { get; set; }
        public string AnswerTxt { get; set; }

        
    }
}
