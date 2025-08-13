namespace Task_5;
public class Quiz
{
    public List<Question> Questions { get; set; } = new List<Question>();

    public void Start()
    {
        int score = 0;
        foreach (var question in Questions)
        {
            question.ShowQuestion("");
            string answer = Console.ReadLine();
                
            if (question.CheckAnswer(answer))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct!");
                Console.ResetColor();
                score += question.QMark;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong!");
                Console.ResetColor();
                
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Final Score: {score} / {Questions.Sum(q => q.QMark)}");
        Console.ResetColor();
        Console.WriteLine();
    }
}