using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string questionBody, int mark, Answer[] answerList, Answer rightAnswer) : base( questionBody, mark, answerList, rightAnswer)
        {
        }
    }
}
