using System;
using System.Collections.Generic;
using System.Text;

namespace metro.Entities
{
    // used for algorithm result
    public class Interval
    {
        public Station begin;
        public Station end;
        public Interval(Station b, Station e)
        {
            begin = b;
            end = e;
        }
    }
}
