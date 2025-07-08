
using System;
using System.Reflection;
namespace Animal_project;

class Sentence
{
    string[] words = new string[3];
    public int count { get; set; }
    public string this[Index wordNum]
    {
        get { return words[wordNum]; }
        set { words[wordNum] = value; }
    }
    public Sentence(string dog, string cat, string fox)
    {
        words[0] = dog;
        words[1] = cat;
        words[2] = fox;
        count = words.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {

        Sentence s = new Sentence("dog", "cat", "fox");

        for (int i = 0; i < s.count; i++)
        {
            Console.WriteLine(s[i]);
        }
    }
}


