namespace _2;

class Program
{
    static void Main(string[] args)
    {
        List<char> Vowels = new List<char> { 'A', 'E', 'I', 'O', 'U' };

        Console.WriteLine("Enter A String: ");
        string s = Console.ReadLine();
        s = s.ToUpper();
        try
        {
            if (!Vowels.Any(v => s.Contains(v)))
            {
                throw new Exception("The string don't contain vowels.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
       
    }
}
