using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    internal class ACoder : ICoder
    {
        const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const int shift = 1;

        public string Encode(string text)
        {
            string fullAlfabet = alfabet + alfabet.ToLower();
            int alfabetLenght = fullAlfabet.Length;
            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                int index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    result += c.ToString();
                }
                else
                {
                    int resultIndex = (alfabetLenght + index + shift) % alfabetLenght;
                    result += fullAlfabet[resultIndex];
                }
            }

            return result;
        }

        public string Decode(string text)
        {
            string fullAlfabet = alfabet + alfabet.ToLower();
            int alfabetLenght = fullAlfabet.Length;
            var result = "";

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                int index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    result += c.ToString();
                }
                else
                {
                    int resultIndex = (alfabetLenght + index - shift) % alfabetLenght;
                    result += fullAlfabet[resultIndex];
                }
            }

            return result;
        }
    }
}
