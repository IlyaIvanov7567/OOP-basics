using System;

namespace StringRevers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Ехал Грека";
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }
    }
}



