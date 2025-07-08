using System.Linq;
using System.Text;
using System.Collections.Generic;
using static System.Console;
using static calculator.Calculator;

namespace calculator;

interface Arithmetic
{
    double Action(double firstNumber, double lastNumber);
}
class FilterArrayElements
{
    static bool b;
    public void Filter(int x, ref double firstNumber, ref double lastNumber)
    {
        int min = x - 1;
        int max = x + 1;
        for (int j = min; j <= max; j++)
        {
            b = double.TryParse(arr[j], out double num);
            if (b == true)
            {
                if (j == max)
                {
                    lastNumber = num;
                }
                else
                {
                    firstNumber = num;
                }
            }
        }
        for (int i = max; i >= min; i--)
        {
            arr.RemoveAt(i);
        }
    }
}
class DivisionAndMultiplication : Arithmetic
{

    public double Action(double firstNumber, double lastNumber)
    {
        FilterArrayElements filter = new FilterArrayElements();
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == "/")
            {
                filter.Filter(i, ref firstNumber, ref lastNumber);
                arr.Insert(i - 1, (firstNumber / lastNumber).ToString());
                i--;
            }
            if (arr[i] == "*")
            {
                filter.Filter(i, ref firstNumber, ref lastNumber);
                arr.Insert(i - 1, (firstNumber * lastNumber).ToString());
                i--;
            }
        }
        return 0;
    }
}
class SubtractionAndAddition : Arithmetic
{
    static double answer;
    public double Action(double firstNumber, double lastNumber)
    {
        FilterArrayElements filter = new FilterArrayElements();
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] == "-")
            {
                filter.Filter(i, ref firstNumber, ref lastNumber);
                arr.Insert(i - 1, (firstNumber - lastNumber).ToString());
                i--;
            }
            if (arr[i] == "+")
            {
                filter.Filter(i, ref firstNumber, ref lastNumber);
                arr.Insert(i - 1, (firstNumber + lastNumber).ToString());
                i--;
            }
            if (i + 1 == arr.Count)
            {
                answer = double.Parse(arr[i]);
            }
        }
        return answer;
    }
}
class Calculator
{
    public double sum;
    bool sequence;
    static string? x, y;
    public static List<string> arr = new List<string>();

    public void AnalyzeAndAnswer(ref double x, int y)
    {
        Arithmetic operators;
        if (sequence == false)
        {
            operators = new DivisionAndMultiplication();
            sequence = true;
        }
        else
        {
            operators = new SubtractionAndAddition();
            sequence = false;
        }
        sum = operators.Action(default, default);
        if (sequence == true)
        {
            AnalyzeAndAnswer(ref x, y);
        }
    }
    public double Arithmetic()
    {
        string? x;
        x = ReadLine();
        if (x.Any((arg) => arg == '='))
        {
            for (int i = 0; x[i] < '='; i++)
            {
                if (char.IsDigit(x[i]))
                {
                    y = y + x[i];
                    if (char.IsDigit(x[i + 1]) == false)
                    {
                        arr.Add(y);
                        y = "";
                    }
                }
                else
                {
                    arr.Add(x[i].ToString());
                }
            }
            AnalyzeAndAnswer(ref sum, 0);
        }
        WriteLine();
        return sum;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        WriteLine(calc.Arithmetic());
    }
}