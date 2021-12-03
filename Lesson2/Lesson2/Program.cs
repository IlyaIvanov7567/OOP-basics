using System;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account(100);
            account.Replenishment(100);
            account.WriteOff(5);
            account.GetInfo();

            Console.ReadKey();
        }
    }

    public enum Type
    {
        no_type,
        checking,
        savings
    }

    public class Account
    {
        private static int _id = 0;
        private decimal _amount;
        private Type _type;

        public int Id
        {
            get { return _id; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Account()
        {
            this.NextId();
        }

        public Account(decimal amount) : this()
        {
            _amount = amount;
        }

        public Account(Type type) : this()
        {
            _type = type;
        }

        public Account(decimal amount, Type type) : this()
        {
            _amount = amount;
            _type = type;
        }

        private void NextId()
        {
            int id = _id + 1;
            _id = id;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Account: {Id}\nType: {Type}\nAmount: {Amount}");
        }

        public void Replenishment(decimal value)
        {
            if (value < 0)
            {
                Console.WriteLine("неверная сумма");
            }
            else
            {
                Amount += value;
            }
        }

        public void WriteOff(decimal value)
        {
            if (value < 0)
            {
                Console.WriteLine("неверная сумма");
            }
            else if (value > Amount)
            {
                Console.WriteLine("недостаточно средств");
            }
            else
            {
                Amount -= value;
            }
        }

        public void Transfer(Account source, int value)
        {
            if (source.Amount <= 0)
            {
                Console.WriteLine("недостаточно средств");
            }
            else
            {
                source.Amount -= value;
                this.Amount += value;
            }
        }
    }
}
