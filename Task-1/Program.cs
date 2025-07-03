namespace Task1;

class Program
{
    static void Main(string[] args)
    {
        int NumOfSmallCarpet, NumOfLargeCarpet;
        Console.WriteLine("How many small Carpets?: ");
        NumOfSmallCarpet = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many Large Carpets?: ");
        NumOfLargeCarpet = Convert.ToInt32(Console.ReadLine());
        int Cost = ((NumOfLargeCarpet * 35) + (NumOfSmallCarpet * 25));


        Console.WriteLine("-------------------");
        Console.WriteLine($"Number Of Small Carpets = {NumOfSmallCarpet}");
        Console.WriteLine($"Number Of Large Carpets = {NumOfLargeCarpet}");
        Console.WriteLine("Price per small Carpets: $25\nPrice per large Carpets: $35");
        Console.WriteLine($"Cost = {Cost}");
        Console.WriteLine("TAX = 6%");
        Console.WriteLine($"Cost After Tax = {Cost * 1.06}");
        Console.WriteLine("-------------------");

    }
}