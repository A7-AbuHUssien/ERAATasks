using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nP - Print numbers");
            Console.WriteLine("A - Add a number");
            Console.WriteLine("M - Display mean of the numbers");
            Console.WriteLine("S - Display the smallest number");
            Console.WriteLine("L - Display the largest number");
            Console.WriteLine("Q - Quit");

            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine().Trim().ToLower();

            switch (input)
            {
                case "p":
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("[] - the list is empty");
                    }
                    else
                    {
                        Console.Write("[ ");
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            Console.Write(numbers[i] + " ");
                        }
                        Console.WriteLine("]");
                    }
                    Console.ReadKey();
                    break;


                case "a":
                    Console.Write("Enter an integer to add: ");
                    string value = Console.ReadLine();
                    int number;
                    if (int.TryParse(value, out number))
                    {
                        numbers.Add(number);
                        Console.WriteLine($"{number} added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                    }
                    Console.ReadKey();
                    break;

                case "m":
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("Unable to calculate the mean - no data");
                    }
                    else
                    {
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }
                        double mean = (double)sum / numbers.Count;
                        Console.WriteLine($"The mean is {mean:F2}");
                    }
                    Console.ReadKey();
                    break;

                case "s":
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("Unable to determine the smallest number - list is empty");
                    }
                    else
                    {
                        int smallest = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] < smallest)
                                smallest = numbers[i];
                        }
                        Console.WriteLine($"The smallest number is {smallest}");
                    }
                    Console.ReadKey();
                    break;

                case "l":
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine("Unable to determine the largest number - list is empty");
                    }
                    else
                    {
                        int largest = numbers[0];
                        for (int i = 1; i < numbers.Count; i++)
                        {
                            if (numbers[i] > largest)
                                largest = numbers[i];
                        }
                        Console.WriteLine($"The largest number is {largest}");
                    }
                    Console.ReadKey();
                    break;

                case "q":
                    Console.WriteLine("Goodbye");
                    running = false;
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Unknown selection, please try again");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
