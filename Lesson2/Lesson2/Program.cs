using System;

namespace Lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Account acc1 = new Account(100);
            Account acc2 = new Account(200);
            Account acc3 = new Account(300);

            Console.WriteLine(acc1.Equals(acc2));

            Console.WriteLine(acc2.GetHashCode());

            Console.WriteLine(acc3);

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
        private static int Count = 1;
        private decimal _amount;
        private Type _type;
        private int _id;

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
            this.NextCount();
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

        private void NextCount()
        {
            _id = Count;
            Count++;
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

        public static bool operator ==(Account acc1, Account acc2)
        {
            return acc1.Id == acc2.Id;
        }

        public static bool operator !=(Account acc1, Account acc2)
        {
            return !(acc1.Id == acc2.Id);

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Account acc = obj as Account;

            return acc.Id == this.Id;
        }

        public bool Equals(Account obj)
        {
            bool areEqual = false;

            if (obj.Id == this.Id)
            {
                areEqual = true;
            }

            return areEqual;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Amount: {Amount}, Type: {Type}";
        }
    }
}

