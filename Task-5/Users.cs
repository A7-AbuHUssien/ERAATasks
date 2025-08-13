namespace Task_5;
public abstract class User { }

public class Teacher : User
{
    public void AddQuestion(Question question, Quiz quiz)
    {
        quiz.Questions.Add(question);
        Console.WriteLine("Question added successfully!");
    }
}

public class Student : User
{
    public void TakeQuiz(Quiz quiz)
    {
        quiz.Start();
    }
}