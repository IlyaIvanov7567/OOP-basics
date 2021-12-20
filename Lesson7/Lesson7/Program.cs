using System;

namespace Lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ACoder aCoder = new ACoder();
            BCoder bCoder = new BCoder();

            Console.WriteLine(bCoder.Encode("АБ1"));
            //Console.WriteLine(bCoder.Decode (""));
            
        }
    }
}
