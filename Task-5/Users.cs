namespace Task_5;
public abstract class User {
    // Maybe add the username and password later, So I did an inheritance.
}
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
