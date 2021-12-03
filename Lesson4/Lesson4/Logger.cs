using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    public abstract class Logger
    {
        public abstract void CustomMessage(string message);
        public abstract void IncorrectValue();
    }

    public sealed class ConsoleLogger : Logger
    {
        public override void CustomMessage(string message)
        {
            Console.WriteLine(message);
        }

        public override void IncorrectValue()
        {
            Console.WriteLine("неверное значение");
        }
    }
}
