using System;
using System.Text.Json;

namespace Task_5;

class Program
{
    private static string FilePath = "/Users/bu-hussien/Private/Projects/Eraa/Task-5/Task-5/questions.json";
    private static void SaveQuestions(List<Question> questions)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        string json = JsonSerializer.Serialize(questions, options);
        File.WriteAllText(FilePath, json);
    }
    private static List<Question> LoadQuestions()
    {
        if (!File.Exists(FilePath))
            return new List<Question>();

        string json = File.ReadAllText(FilePath);
        var options = new JsonSerializerOptions { };
        return JsonSerializer.Deserialize<List<Question>>(json, options) ?? new List<Question>();
    }
    private static Question AskTeacher()
    {
        Console.Write("Question Level:");
        string level = Console.ReadLine();

        Console.Write("Question Header: ");
        string header = Console.ReadLine();

        Console.Write("Question Body: ");
        string body = Console.ReadLine();

        Console.Write("Marks: ");
        int marks = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("\nWhat The Question Type?");
        Console.WriteLine("[1] true false");
        Console.WriteLine("[2] MultiChoice");
        Console.WriteLine("[3] Complete");
        string type = Console.ReadLine();

        string correctAnswer;

        switch (type)
        {
            case "1":
                Console.Write("The Correct Answer (True/False):");
                bool correct = bool.Parse(Console.ReadLine());
                return new TrueFalseQuestion(level, header, body, marks, correct);

            case "2":
                List<string> answers = new List<string>();
                Console.WriteLine("Answers??");
                Console.Write("[1]: ");
                string answer = Console.ReadLine();
                answers.Add(answer);
                Console.Write("[2]: ");
                answer = Console.ReadLine();
                answers.Add(answer);
                Console.Write("[3]: ");
                answer = Console.ReadLine();
                answers.Add(answer);
                Console.Write("[4]: ");
                answer = Console.ReadLine();
                answers.Add(answer);
                Console.Write("Correct at Index: ");
                correctAnswer = Console.ReadLine();
                return new MultipleChoiceQuestion(level, header, body, marks, answers, correctAnswer);
            case "3":
                Console.Write("Correct: ");
                correctAnswer = Console.ReadLine();
                return new CompleteQuestion(level, header, body, marks, correctAnswer);
        }

        return null;
    }

    static void Main(string[] args)
    {
        Quiz quiz = new Quiz();
        bool x = true;
        do
        {
            string role = "";
            Console.WriteLine("[1] Teacher");
            Console.WriteLine("[2] Student");
            Console.WriteLine("[3] Exit");
            Console.WriteLine("-----------------");
            role = Console.ReadLine();
            switch (role)
            {
                case "1":
                    quiz.Questions = LoadQuestions();
                    Teacher teacher = new Teacher();
                    var q = AskTeacher();
                    if (q != null)
                    {
                        teacher.AddQuestion(q, quiz);
                        SaveQuestions(quiz.Questions);
                    }
                    else
                    {
                        Console.WriteLine("Invalid question type. No question added.");
                    }

                    break;
                case "2":
                    Student student = new Student();
                    quiz.Questions.Clear();
                    quiz.Questions = LoadQuestions();
                    student.TakeQuiz(quiz);
                    break;
                case "3":
                    x = false;
                    break;
            }

            Console.ReadKey();
        } while (x);
    }
}