using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace metro.Entities
{
    public class Metro
    {
        public Metro(string id,string name,List<Station> stations)
        {
            this.Id = id;
            this.Name = name;
            this._stations = stations;
        }
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            private set;
        }
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            private set;
        }
        //[JsonPropertyName("stations")]
        private readonly List<Station> _stations;
        public List<Station> Stations
        {
            get
            {
                return _stations;
            }
        }

        public List<Station> GetStationsBetween(int bpos,int epos)
        {
            bool flag = true;
            if (bpos > epos)
            {
                flag = false;
                bpos = bpos + epos - (epos = bpos);
            }
            var ret = Stations.FindAll(u => u.Pos >= bpos && u.Pos <= epos);
            ret.Sort((a,b) => flag ? (a.Pos - b.Pos) : (b.Pos - a.Pos));
            return ret;
        }

        public List<Station> GetStations(){
            return this.Stations;
        }
    }
}
