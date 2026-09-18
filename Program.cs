using System.Diagnostics;

namespace C45_G80_EXAM02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):");
            int examType;

            do
            {
              examType = int.Parse(Console.ReadLine());
                if(examType != 1 && examType != 2)
                {
                    Console.WriteLine("Invalid choice. Please enter 1 for Practical or 2 for Final:");
                }
            }
            while (examType != 1 && examType != 2);

            Console.WriteLine("Please enter the time for the exam (30 to 180 minutes):");
            int timeInMinutes;
            do
            {
                timeInMinutes = int.Parse(Console.ReadLine());
                if(timeInMinutes < 30 || timeInMinutes > 180)
                {
                    Console.WriteLine("Invalid Duration Time");
                }
            }
            while (timeInMinutes < 30 || timeInMinutes > 180);
            TimeSpan examTime = TimeSpan.FromMinutes(timeInMinutes);

            Console.WriteLine("Please enter the number of the questions:");
            int numberOfQ;
            do
            {
                numberOfQ = int.Parse(Console.ReadLine());
                if (numberOfQ <= 0)
                {
                    Console.WriteLine("Invalid Please try again");
                }
            }
            while (numberOfQ <= 0);





            Question[] questions = new Question[numberOfQ];

            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Please enter the question {i + 1} body:");
                string qBody = Console.ReadLine();

                Console.WriteLine($"Please enter the question {i + 1} mark:");
                int qMark = int.Parse(Console.ReadLine());

                int qType;

                
                if (examType == 1)
                {
                    
                    qType = 1;
                }
                else
                {
                    
                    Console.WriteLine("Enter question type:");
                    Console.WriteLine("1. MCQ");
                    Console.WriteLine("2. True / False");
                    qType = int.Parse(Console.ReadLine());
                }

                if (qType == 1)
                {
                    // MCQ

                    Answer[] answer = new Answer[4];
                    Answer rightAnswer = null;

                    for (int j = 0; j < answer.Length; j++)
                    {
                        Console.WriteLine($"Please enter choice number {j + 1}:");
                        string possibleAns = Console.ReadLine();
                        Answer answer01 = new Answer(j + 1, possibleAns);
                        answer[j] = answer01;
                    }

                    Console.WriteLine("Please enter the id of the correct answer (1 to 4):");

                    int correctAns;

                    do
                    {
                        correctAns = int.Parse(Console.ReadLine());

                        if (correctAns < 1 || correctAns > 4)
                        {
                            Console.WriteLine("Invalid Option");
                        }

                    } while (correctAns < 1 || correctAns > 4);

                    foreach (Answer ans in answer)
                    {
                        if (ans.AnswerId == correctAns)
                        {
                            rightAnswer = ans;
                        }
                    }

                    MCQQuestion mCQ = new MCQQuestion(qBody, qMark, answer, rightAnswer);
                    questions[i] = mCQ;
                }
                else if (qType == 2)
                {
                    Answer[] answer = new Answer[2];
                    string[] answerTexts = { "True", "False" };
                    Answer rightAnswer = null;

                    for (int j = 0; j < answer.Length; j++)
                    {
                        Answer answer02 = new Answer(j + 1, answerTexts[j]);
                        answer[j] = answer02;
                        
                    }
                    Console.WriteLine("Please enter the id of the correct answer (1 for True, 2 for False):");
                    int correctAnsId;
                    do
                    {
                        correctAnsId = int.Parse(Console.ReadLine());

                        if (correctAnsId != 1 && correctAnsId != 2)
                        {
                            Console.WriteLine("Invalid Option");
                        }

                    } while (correctAnsId != 1 && correctAnsId != 2);

                    foreach ( Answer ans in answer)
                    {
                        if(ans.AnswerId == correctAnsId)
                        {
                            rightAnswer = ans;
                        }
                    }
                    TrueFalseQuestion trueFalseQuestion = new TrueFalseQuestion(qBody, qMark, answer, rightAnswer);
                    questions[i] = trueFalseQuestion;

                }
                else
                {
                    Console.WriteLine("Invalid Question Type");
                }
            }
            Subject subject = new Subject(1, "c#");
            Answer[] givenAnswers = new Answer[numberOfQ];

            Exam exam;

            if (examType == 1)
            {
                exam = new PracticalExam(examTime,subject,questions , givenAnswers);
            }
            else
            {
                exam = new FinalExam(examTime, subject, questions, givenAnswers);
                

            }

            Console.WriteLine("Do you want to start the exam? (y/n)");
            string startEXAM;

            do
            {

                startEXAM = Console.ReadLine();
                if(startEXAM != "y" && startEXAM != "n")
                {
                    Console.WriteLine("Invalid Option");
                }

            }
            while (startEXAM != "y" && startEXAM != "n");


            if (startEXAM == "y")
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                exam.ShowExam();
                stopwatch.Stop();
                TimeSpan Time = stopwatch.Elapsed;
               
                Console.WriteLine($"Time Taken: {Time}");
                
                if (examType == 2)
                {
                    FinalExam finalExam = (FinalExam)exam;
                    int grade = finalExam.AnswerGrade();
                    Console.WriteLine($"Your Grade: {grade}");

                }
            }


        }


    }
}

