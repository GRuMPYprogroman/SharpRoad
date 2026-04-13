using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine()!);

        string[] words = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            words[i] = Console.ReadLine()!;
        }

        string prefix = LongestCommonPrefix(words);
        Console.WriteLine("Наибольший общий префикс: " + prefix);
    }

    static string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
            return "";

        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (string.IsNullOrEmpty(prefix))
                    return "";
            }
        }

        return prefix;
    }
}