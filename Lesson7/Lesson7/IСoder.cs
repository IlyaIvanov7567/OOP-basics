using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    internal interface ICoder
    {
        string Encode(string text);
        string Decode(string text);
    }
}
