﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEABrowser.Model
{
    public class CallClass : ProductClass
    {
        public string Path { get; set; }
        public long CallLengthInMS { get; set; }
    }
}
