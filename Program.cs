namespace Palindrome;
using static Console;
class Program
{
    static string? str;
    static void Main(string[] args)
    {
        str = ReadLine();
        for (int i = 0; i < str.Length; i++)
        {
            if (str[str.Length - (i + 1)] == str[i])
            {
                if (++i == str.Length)
                {
                    WriteLine($"This is a palindrome -> {str}");
                }
            }
            else
            {
                WriteLine("This is not a palindrome.");
                break;
            }
        }
    }
}
