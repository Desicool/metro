using System;
using System.Collections.Generic;
using System.Text;

namespace metro.Entities
{
    // used for algorithm result
    public class Interval
    {
        public string begin;
        public string end;
        public Interval(string b, string e)
        {
            begin = b;
            end = e;
        }
    }
}
