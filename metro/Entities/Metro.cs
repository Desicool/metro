using System;
using System.Collections.Generic;

namespace metro.Entities
{
    public class Metro
    {
        public Metro(string id,string name,List<Station> stations)
        {
            this.Id = id;
            this.Name = name;
            this.stations = stations;
        }

        public string Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        private readonly List<Station> stations;

        public List<Station> GetStationsBetween(Station begin,Station end)
        {
            if (!stations.Contains(begin) || !stations.Contains(end))
            {
                throw new Exception("Cannot find station");
            }
            int bpos = stations.FindIndex(u => u.Pos == begin.Pos);
            int epos = stations.FindIndex(u => u.Pos == end.Pos);
            bool flag = true;
            if (bpos > epos)
            {
                flag = false;
                bpos = bpos + epos - (epos = bpos);
            }
            var ret = stations.FindAll(u => u.Pos >= bpos && u.Pos <= epos);
            ret.Sort((a,b) => flag ? (a.Pos - b.Pos) : (b.Pos - a.Pos));
            return ret;
        }
    }
}
