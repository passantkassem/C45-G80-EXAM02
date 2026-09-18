using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal abstract class Exam
    {
        protected Exam(TimeSpan time, Subject subject, Question[] questions, Answer[] givenAnswers )
        {
            Time = time;
            Subject = subject;
            Questions = questions;
            GivenAnswers = givenAnswers;
        }

        public TimeSpan Time { get; set; }
       
        public Subject Subject { get; set; }
        public int NumberOfQuestions { get { return Questions.Length; } }
        public Question [] Questions { get; set; }
        public Answer[] GivenAnswers { get; set; }
        public abstract void ShowExam();
    }
}
