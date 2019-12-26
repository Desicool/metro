using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

    public class Transfer : TableEntity
    {
        public List<Route> routes { get; set; }
        public string route { get; set; }

        public Transfer()
        {

        }

        public Transfer(string start,string end,List<Route> r)
        {
            PartitionKey = start;
            RowKey = end;
            route = JsonConvert.SerializeObject(r);
        }

        public void ToRoute()
        {
            routes = JsonConvert.DeserializeObject<List<Route>>(route);
        }
    }
}
