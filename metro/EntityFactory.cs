using System;
using System.Collections.Generic;
using metro.Entities;

namespace metro
{
    public static class EntityFactory
    {
        public static Dictionary<string,Metro> metroDic = new Dictionary<string, Metro>();
        public static Dictionary<string, Station> stationDic = new Dictionary<string, Station>();

        public static void Init()
        {
            //load stations

            var metroList = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("һ����","1"),
                new Tuple<string, string>("������","2"),
                new Tuple<string, string>("������","3"),
                new Tuple<string, string>("�ĺ���","4")
            };

            foreach(var t in metroList)
            {
                var name = t.Item1;
                var id = t.Item2;
                var stations = stationDic.Values.FindAll(x => x.metro == id);
                var metro = new Metro(id, name,stations);
                metroDic.Add(id, metro);
            }
        }
    }
}
