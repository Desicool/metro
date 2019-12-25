using metro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace metro.Algorithm
{
    public class KthShortest
    {
        private readonly List<Station> stations;
        private Station start;
        public KthShortest(List<Station> stations)
        {
            this.stations = stations;
        }
    }
}
