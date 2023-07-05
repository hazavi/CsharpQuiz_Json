using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace MyQuiz // Note: actual namespace depends on the project name.
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string Answer { get; set; }
        public string Desc { get; set; }
    }

    public class Quiz
    {
        public List<Question> Questions { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Specify the path to your JSON file
            string filePath = "C:/Users/ha/source/repos/MyQuiz/MyQuiz/cquiz.json";

            // Read the JSON file
            string json = File.ReadAllText(filePath);

            // Deserialize the JSON into a Quiz object
            Quiz quiz = JsonConvert.DeserializeObject<Quiz>(json);

            // Now you can access the questions and their properties
            List<Question> questions = quiz.Questions;

            int score = 0;
            int totalQuestions = questions.Count;
            int qNum = 1;

            // Loop through each question
            for (int i = 0; i < totalQuestions; i++)
            {
                Question question = questions[i];

                // Display the question
                Console.WriteLine(qNum + ".)" + question.QuestionText);
                qNum++;
                for (int j = 0; j < question.Options.Count; j++)
                {
                    Console.WriteLine($"{question.Options[j]}");
                }

                // Prompt the user for their answer
                Console.Write("Enter your answer: ");
                string userAnswer = Console.ReadLine();

                // Validate the user's answer
                if (userAnswer.ToLower() == question.Answer.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nRigtigt!\n");
                    Console.ResetColor();
                    Console.WriteLine(question.Desc);
                    Console.ReadKey();
                    Console.Clear();
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nForkert!\n");
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Correct answer: " + question.Answer + "\n");
                    Console.ResetColor();
                    Console.WriteLine(question.Desc);
                    Console.ReadKey();
                    Console.Clear();


                }
            }

            // Display the final score
            Console.WriteLine("Quiz completed. Your score: " + score + "/" + totalQuestions);

            Console.ReadLine();

        }
    }

}

