﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class FolderObject : DataObject
    {
        public string size;
        public override string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = Path.FolderSize();
            }
        }
    }
}