using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal abstract class Question
    {
        protected Question( string questionBody, int mark, Answer[] answerList, Answer rightAnswer)
        {
            
            QuestionBody = questionBody;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }

        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public Answer RightAnswer { get; set; }



    }
}
