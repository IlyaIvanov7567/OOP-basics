using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    internal class BCoder : ICoder
    {
        string alphabetLower = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string alphabetUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        

        public string Encode(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                for (int i = 0; i < alphabetLower.Length; i++)
                {

                    if (c == alphabetLower[i])
                    {
                        result += alphabetLower[alphabetLower.Length - 1 - i];
                    }
                    if (c == alphabetUpper[i])
                    {
                        result += alphabetUpper[alphabetUpper.Length - 1 - i];
                    }
                }
            }
            return result;
        }

        public string Decode(string text)
        {
            string result = "";

            foreach (char c in text)
            {
                for (int i = 0; i < alphabetLower.Length; i++)
                {
                    if (c == alphabetLower[i])
                    {
                        result += alphabetLower[alphabetLower.Length - i - 1];

                    }
                    if (c == alphabetUpper[i])
                    {
                        result += alphabetUpper[alphabetUpper.Length - i  - 1];
                    }
                }
            }
            return result;
        }
    }
}
