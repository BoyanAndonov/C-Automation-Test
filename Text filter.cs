using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        
        Console.WriteLine("Въведете текст:");
        string inputText = Console.ReadLine();

        
        PrintOccurrences(inputText, "Оборот", 15);
    }

    static void PrintOccurrences(string input, string targetWord, int charactersAfter)
    {
        
        string pattern = $@"{Regex.Escape(targetWord)}\s*(\d{{0,{charactersAfter}}})";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        MatchCollection matches = regex.Matches(input);

        foreach (Match match in matches)
        {
            Console.WriteLine("Резултат:");
            Console.WriteLine($"{targetWord}{match.Groups[1].Value}");
        }
       
        if (matches.Count == 0)
        {
            Console.WriteLine($"Думата '{targetWord}' не е намерена в текста.");
        }
    }
}
//Тази програма е написан за Светлан Дамянов
//и намира във всеки текст думата "Оборот "
//и числата  след него и ги принтира на конзолата