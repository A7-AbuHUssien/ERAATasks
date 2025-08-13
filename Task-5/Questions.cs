using System;
using System.Text.Json.Serialization; 

namespace Task_5;

// Attributes for Dealing With the File
[JsonDerivedType(typeof(TrueFalseQuestion), typeDiscriminator: "trueFalse")]
[JsonDerivedType(typeof(MultipleChoiceQuestion), typeDiscriminator: "multiChoice")]
[JsonDerivedType(typeof(CompleteQuestion), typeDiscriminator: "complete")]
public abstract class Question
{
    public string QLevel { get; set; }
    public string QHeader { get; set; }
    public string QBody { get; set; }
    public int QMark { get; set; }

    public Question(string qLevel, string qHeader, string qBody, int qMark)
    {
        QLevel = qLevel;
        QHeader = qHeader;
        QBody = qBody;
        QMark = qMark;
    }

    public abstract bool CheckAnswer(string answer);
    public abstract void ShowQuestion(string answer);
}

public class TrueFalseQuestion : Question
{
    public bool CorrectAnswer { get; set; }

    public TrueFalseQuestion(string qLevel, string qHeader, string qBody, int qMark, bool correctAnswer)
        : base(qLevel, qHeader, qBody, qMark)
    {
        CorrectAnswer = correctAnswer;
    }

    public override void ShowQuestion(string answer)
    {
        Console.Write($"{QHeader}({QLevel})\n");
        Console.WriteLine($"Question Body: {QBody} (True/False)");
        Console.WriteLine("-------------------------");
        Console.Write("Your Answer: ");
    }

    public override bool CheckAnswer(string answer)
    {
        if (string.IsNullOrWhiteSpace(answer)) return false;
        string normalizedAnswer = answer.Trim().ToLower();
        return CorrectAnswer
            ? normalizedAnswer == "true" || normalizedAnswer == "t" || normalizedAnswer == "1"
            : normalizedAnswer == "false" || normalizedAnswer == "f" || normalizedAnswer == "0";
    }
}

public class MultipleChoiceQuestion : Question
{
    public List<string> Options { get; set; }
    public string CorrectOption { get; set; }

    public MultipleChoiceQuestion(
        string qLevel,
        string qHeader,
        string qBody,
        int qMark,
        List<string> options,
        string correctOption)
        : base(qLevel, qHeader, qBody, qMark)
    {
        Options = options;
        CorrectOption = correctOption;
    }

    public override void ShowQuestion(string answer)
    {
        Console.Write($"{QHeader}({QLevel})\n");
        Console.WriteLine($"{QBody}");
        Console.WriteLine("-------------------------");
        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }

        Console.WriteLine("-------------------------");
        Console.Write("Enter the Index of your answer: ");
    }

    public override bool CheckAnswer(string answer)
    {
        return CorrectOption == answer;
    }
}

public class CompleteQuestion : Question
{
    public string CorrectAnswer { get; set; }

    public CompleteQuestion(
        string qLevel,
        string qHeader,
        string qBody,
        int qMark,
        string correctAnswer)
        : base(qLevel, qHeader, qBody, qMark)
    {
        CorrectAnswer = correctAnswer;
    }

    public override bool CheckAnswer(string answer)
    {
        return string.Equals(answer.Trim(), CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    public override void ShowQuestion(string answer)
    {
        Console.Write($"{QHeader}({QLevel})\n");
        Console.WriteLine($"{QBody}");
        Console.WriteLine("-------------------------");

        if (!string.IsNullOrEmpty(answer))
        {
            Console.WriteLine($"Your Answer: {answer}");
            Console.WriteLine($"Correct Answer: {CorrectAnswer}");
            Console.WriteLine(CheckAnswer(answer) ? "Result: Correct!" : "Result: Incorrect.");
        }
        else
        {
            Console.Write("Enter your answer: ");
        }
    }
}