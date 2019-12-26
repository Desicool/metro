using System;
using System.Collections.Generic;
using System.Text;

namespace metro.Entities
{
    // used for algorithm result
    public class Interval
    {
        public Station begin { get; }
        public Station end { get; }
        public Interval(Station b, Station e)
        {
            begin = b;
            end = e;
        }
    }

    public class Route
    {
        public List<Interval> intervals
        {
            get;
        }
        public int size;
        public Route(List<Interval> i, int s = 114)
        {
            intervals = i;
            size = s;
        }
    };
}
