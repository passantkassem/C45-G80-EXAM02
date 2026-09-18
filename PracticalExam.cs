using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G80_EXAM02
{
    internal class PracticalExam:Exam
    {
        public PracticalExam(TimeSpan time, Subject subject, Question[] questions, Answer[] givenAnswers) : base(time, subject, questions, givenAnswers)
        {
        }

        public override void ShowExam()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
               
                Console.WriteLine(Questions[i].QuestionBody);
                for (int j = 0; j < Questions[i].AnswerList.Length; j++)
                {
                    Console.WriteLine($"{Questions[i].AnswerList[j].AnswerId}. " + $"{Questions[i].AnswerList[j].AnswerTxt}");
                }
                Console.Write("Enter your answer: ");
                string userAnswer = Console.ReadLine();
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
                Console.WriteLine($"Correct Answer: {Questions[i].RightAnswer.AnswerTxt}");

            }

        }
    }
}

