using System;
namespace metro.Entities
{
    public class Station
    {
        public Station()
        {
        }

        public Station(string id,string name,string metro,int pos)
        {
            Id = id;
            Name = name;
            Metro = metro;
            Pos = pos;
        }

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Metro
        {
            get;
            set;
        }

        public int Pos
        {
            get;
            set;
        }

    }
}
