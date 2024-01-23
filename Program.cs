using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "end")
            {
                break;
            }

            string[] commandParts = command.Split(' ');
            string action = commandParts[0];

            if (action == "Contains")
            {
                int numberToCheck = int.Parse(commandParts[1]);
                if (numbers.Contains(numberToCheck))
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No such number");
                }
            }
            else if (action == "PrintEven")
            {
                List<int> evenNumbers = numbers.Where(num => num % 2 == 0).ToList();
                Console.WriteLine(string.Join(" ", evenNumbers));
            }
            else if (action == "PrintOdd")
            {
                List<int> oddNumbers = numbers.Where(num => num % 2 != 0).ToList();
                Console.WriteLine(string.Join(" ", oddNumbers));
            }
            else if (action == "GetSum")
            {
                int sum = numbers.Sum();
                Console.WriteLine(sum);
            }
            else if (action == "Filter")
            {
                string condition = commandParts[1];
                int number = int.Parse(commandParts[2]);

                if (condition == ">")
                {
                    List<int> filteredNumbers = numbers.Where(num => num > number).ToList();
                    Console.WriteLine(string.Join(" ", filteredNumbers));
                }
                else if (condition == "<")
                {
                    List<int> filteredNumbers = numbers.Where(num => num < number).ToList();
                    Console.WriteLine(string.Join(" ", filteredNumbers));
                }
                else if (condition == ">=")
                {
                    List<int> filteredNumbers = numbers.Where(num => num >= number).ToList();
                    Console.WriteLine(string.Join(" ", filteredNumbers));
                }
                else if (condition == "<=")
                {
                    List<int> filteredNumbers = numbers.Where(num => num <= number).ToList();
                    Console.WriteLine(string.Join(" ", filteredNumbers));
                }
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}
