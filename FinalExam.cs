using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace C45_G80_EXAM02
{
    internal class FinalExam : Exam
    {

        public FinalExam(TimeSpan time, Subject subject, Question[] questions, Answer[] givenAnswers) : base(time, subject, questions, givenAnswers)
        {
        }

        public  int AnswerGrade()
        {
            int grade = 0;
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i].RightAnswer.AnswerId == GivenAnswers[i].AnswerId)
                {
                    grade += Questions[i].Mark;
                }
                

            }
            return grade;
        }


        public override void ShowExam()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Questions.Length; i++)
            {
                if (stopwatch.Elapsed >= Time)
                {
                    Console.WriteLine("Time Out!");
                    return;
                }

                Console.WriteLine(Questions[i].QuestionBody);

                for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                {
                    Console.WriteLine($"{Questions[i].AnswerList[j].AnswerId}. " + $"{Questions[i].AnswerList[j].AnswerTxt}");
                }

                Console.Write("Enter your answer: ");
                string userAnswer = Console.ReadLine();

                if (stopwatch.Elapsed >= Time)
                {
                    Console.WriteLine("Time Out!");
                    return;
                }

                if (int.TryParse(userAnswer, out int answerId))
                {
                    for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                    {
                        if (Questions[i].AnswerList[j].AnswerId == answerId)
                        {
                            GivenAnswers[i] = Questions[i].AnswerList[j];
                        }
                    }
                }
            }

            stopwatch.Stop();
        }

    }
}
