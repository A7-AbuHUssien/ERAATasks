namespace _1;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> Nums = new  List<int>();
        Console.WriteLine("Enter Numbers    : ");
        string sNums = Console.ReadLine();

        for (int i = 0; i < sNums.Length; i++)
        {
            if (sNums[i] == ' ')
                continue;
            try
            {
                int num = int.Parse(sNums[i].ToString());
                if (Nums.Contains(num))
                    throw new Exception("Duplicate number found: " + num);
                Nums.Add(num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine("Numbers Without Repetition: ");
        foreach (int num in Nums)
        {
            Console.Write(num + " ");
        }
    }
}