using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    interface IStorageItem
    {
        string Path { get; set; }
        string Name { get; set; }
        string Size { get; set; }
        string LastAccess { get; set; }
    }
}
