using System;

namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber x = new RationalNumber(5, 7);
            RationalNumber y = new RationalNumber(5, 7);
            RationalNumber z = x/y;
            Console.WriteLine(z.ToString());
        }
    }

    class RationalNumber
    {
        private int _numerator;
        private uint _denominator;

        public int Numerator
        {
            get { return _numerator; }
        }

        public uint Denominator
        {
            get { return _denominator; }
        }

        public RationalNumber(int numerator, uint denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("The denominator must be non-zero");

            _numerator = numerator;
            _denominator = denominator;

            ReduceToLowestTerms();
        }

        private void ReduceToLowestTerms()
        {
            int greatestCommonDivisor = RationalNumber.GetGCD(_numerator, (int)_denominator);
            _numerator /= greatestCommonDivisor;
            _denominator = (uint)(_denominator / greatestCommonDivisor);
        }

        private static int GetGCD(int term1, int term2)
        {
            if (term2 == 0)
                return term1;
            else
                return GetGCD(term2, term1 % term2);
        }

        #region +
        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber((int)((r1.Numerator * r2.Denominator)
                + (r2.Numerator * r1.Denominator)), r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator +(RationalNumber r1, int value)
        {
            return new RationalNumber((int)(r1.Numerator + value * r1.Denominator), r1.Denominator);
        }

        public static RationalNumber operator +(int value, RationalNumber r1)
        {
            return new RationalNumber((int)(r1.Numerator + value * r1.Denominator), r1.Denominator);

        }
        #endregion

        #region -
        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber((int)((r1.Numerator * r2.Denominator)
                - (r2.Numerator * r1.Denominator)), r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, int value)
        {
            return new RationalNumber((int)(r1.Numerator - value * r1.Denominator), r1.Denominator);
        }

        public static RationalNumber operator -(int value, RationalNumber r1)
        {
            return new RationalNumber((int)(r1.Numerator - value * r1.Denominator), r1.Denominator);
        }
        #endregion

        #region *
        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, int value)
        {
            return new RationalNumber(r1.Numerator * value, r1.Denominator);
        }

        public static RationalNumber operator *(int value, RationalNumber r1)
        {
            return new RationalNumber(r1.Numerator * value, r1.Denominator);
        }
        #endregion

        #region /
        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber((int)(r1.Numerator * r2.Denominator), (uint)(r1.Denominator * r2.Numerator));
        }

        public static RationalNumber operator /(RationalNumber r1, int value)
        {
            return new RationalNumber(r1.Numerator, (uint)(r1.Denominator * value));
        }

        public static RationalNumber operator /(int value, RationalNumber r1)
        {
            return new RationalNumber(r1.Numerator, (uint)(r1.Denominator * value));
        }
        #endregion

        #region %
        public static RationalNumber operator %(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                if (r1.Numerator < r2.Numerator)
                    return r1;
                else
                    return new RationalNumber(r1.Numerator - r2.Numerator, r1.Denominator);
            }
            else
            {
                if (r1.Numerator * r2.Denominator < r2.Numerator * r1.Denominator)
                    return r1;
                else
                return new RationalNumber((r1.Numerator * (int)r2.Denominator) - (r2.Numerator * (int)r1.Denominator),
                    r1.Denominator * r2.Denominator);
            }
        }
        #endregion 

        #region ++, --
        public static RationalNumber operator ++(RationalNumber r1)
        {
            return new RationalNumber((int)(r1.Numerator + r1.Denominator), r1.Denominator);
        }

        public static RationalNumber operator --(RationalNumber r1)
        {
            return new RationalNumber((int)(r1.Numerator - r1.Denominator), r1.Denominator);
        }
        #endregion

        #region >
        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator > r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator > r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) > (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator >(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator > r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator > r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) > (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator >(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator > r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator > r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) > (r2.Numerator * r1.Denominator));
            }
        }
        #endregion

        #region <
        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator < r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator < r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) < (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator <(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator < r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator < r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) < (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator <(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator < r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator < r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) < (r2.Numerator * r1.Denominator));
            }
        }
        #endregion

        #region >=
        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator >= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator >= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) >= (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator >=(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator >= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator >= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) >= (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator >=(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator >= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator >= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) >= (r2.Numerator * r1.Denominator));
            }
        }
        #endregion

        #region <=
        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator <= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator <= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) <= (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator <=(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator <= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator <= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) <= (r2.Numerator * r1.Denominator));
            }
        }

        public static bool operator <=(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator <= r2.Numerator;
            }
            else if (r1.Numerator == r2.Numerator)
            {
                return r2.Denominator <= r1.Denominator;
            }
            else
            {
                return ((r1.Numerator * r2.Denominator) <= (r2.Numerator * r1.Denominator));
            }
        }
        #endregion

        #region Преведение типов
        public static explicit operator int(RationalNumber r1)
        {
            if (r1.Numerator < r1.Denominator)
                throw new ArgumentException("Cannot be explicitly converted");

            return (int)(r1.Numerator / r1.Denominator);
        }

        public static implicit operator float(RationalNumber r1)
        {
            return (float)r1.Numerator / (float)r1.Denominator;
        }
        #endregion

        #region ==
        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            return (r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator);
        }

        public static bool operator ==(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);

            return (r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator);
        }

        public static bool operator ==(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);

            return (r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator);
        }
        #endregion

        #region !=       
        public static bool operator !=(RationalNumber r1, int value)
        {
            RationalNumber r2 = new RationalNumber(value, 1);

            return (r1.Numerator != r2.Numerator || r1.Denominator != r2.Denominator);
        }

        public static bool operator !=(int value, RationalNumber r1)
        {
            RationalNumber r2 = new RationalNumber(value, 1);

            return (r1.Numerator != r2.Numerator || r1.Denominator != r2.Denominator);
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return (r1.Numerator != r2.Numerator || r1.Denominator != r2.Denominator);
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            RationalNumber r1 = obj as RationalNumber;

            if (r1 as RationalNumber == null)
                return false;

            return r1 == this.Numerator && r1.Denominator == this.Denominator;
        }

        public bool Equals(RationalNumber obj)
        {
            if (obj == null)
                return false;

            return obj.Numerator == this.Numerator && obj.Denominator == this.Denominator;
        }
        #endregion

        public override string ToString()
        {
            return string.Format("{0}/{1}", _numerator, _denominator);
        }
    }

}