using metro.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace metro.Initialize
{
    public class KthShortest
    {
        private static readonly Dictionary<string, int> stationDic = new Dictionary<string, int>();
        private static readonly List<Station> stationList = new List<Station>();
        private static readonly List<string> stations = new List<string>();
        private static readonly List<List<Edge>> edges = new List<List<Edge>>();
        public static Dictionary<KeyValuePair<string, string>, List<Route>> routeDic = new Dictionary<KeyValuePair<string, string>, List<Route>>();
        public static List<int> dis = new List<int>();
        private static List<int> from = new List<int>();
        private int end;
        private int start;
        private int k = 3;

        public static void Init(List<Metro> metros)
        {
            metros.ForEach(x =>
            {
                var stas = x.GetStations();
                stas.ForEach(u =>
                {
                    var index = stations.Count();
                    stationDic.Add(u.Id, index);
                    stations.Add(u.Id);
                    stationList.Add(u);
                    edges.Add(new List<Edge>());
                    dis.Add(19260817);
                    from.Add(index);
                    Console.Out.Write($"{u.Id},{u.Name}\r\n");
                }
                );
                for (int i = 1; i < stas.Count(); i++)
                {
                    edges[stationDic[stas[i - 1].Id]].Add(new Edge(stationDic[stas[i - 1].Id],stationDic[stas[i].Id],10));
                    edges[stationDic[stas[i].Id]].Add(new Edge(stationDic[stas[i].Id],stationDic[stas[i - 1].Id],10));
                }
            }
            );
            var trans = stationList.GroupBy(u => u.Name).Where(u => u.Count() > 1).ToList();
            trans.ForEach(u =>
            {
                var enumerator = u.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var temp = enumerator;
                    var node = enumerator.Current;
                    while (enumerator.MoveNext())
                    {
                        if (node != enumerator.Current && node.Metro != "line4" && enumerator.Current.Metro != "line4")
                        {
                            {
                                edges[stationDic[node.Id]].Add(new Edge(stationDic[node.Id], stationDic[enumerator.Current.Id], 16));
                                edges[stationDic[enumerator.Current.Id]].Add(new Edge(stationDic[enumerator.Current.Id], stationDic[node.Id], 16));
                            }
                            
                        }
                    }
                    enumerator = temp;
                }
            });
        }

        public KthShortest()
        {
            for(int j = 0;j < stationList.Count; j++)
            {
                end = j;
                for(int i = 0;i < stationList.Count; i++)
                {
                    dis[i] = 19260817;
                    from[i] = i;
                }
                Dijkstra(j);
                for (int i = 0; i < stationList.Count; i++)
                {
                    if (i == j) continue;
                    if (stationList[i].Metro == stationList[j].Metro)
                    {
                        Interval route = new Interval(stationList[i], stationList[j]);
                        SaveRoute(stationList[i].Id, stationList[j].Id,new List<Interval> { route });
                    }
                    else
                    {
                        start = i;
                        k = 10;
                        BFS(i);
                    }
                }
            }
            Console.Out.Write("Finished");
        }

        private void Dijkstra(int a)
        {
            bool[] vis = new bool[1919];
            dis[a] = 0;
            var que = new PriorityQueue<KeyValuePair<int, int>>(new Comparer1());
            que.Push(new KeyValuePair<int, int>(0, a));
            while (que.Count > 0)
            {
                KeyValuePair<int, int> p = que.Top();
                que.Pop();
                if (vis[p.Value]) continue;
                vis[p.Value] = true;
                int num = p.Key;
                for (int i = 0; i < edges[p.Value].Count(); i++)
                {
                    var e = edges[p.Value][i];
                    if (!vis[e.v] && dis[e.v] > num + e.val)
                    {
                        dis[e.v] = num + e.val;
                        from[e.v] = p.Value;
                        que.Push(new KeyValuePair<int, int>(dis[e.v], e.v));
                    }
                }
            }
        }

        private void BFS(int a)
        {//BFS
            var que = new PriorityQueue<Node>(new Comparer2());
            que.Push(new Node(a, 0, new List<int>()));
            while (que.Count > 0)
            {
                Node node = que.Top();
                que.Pop();
                var to = node.from;
                if (node.to == end)
                {//到达终点次数
                    BuildRoute(a,node.from);
                    k--;
                    if (k == 0)
                    {
                        return;
                    }
                    continue;
                }
                to.Add(node.to);
                if (to.Count() > 50) continue;
                for (int i = 0; i < edges[node.to].Count(); i++)
                {//扩散（跑反向边）
                    var e = edges[node.to][i];
                    if (to.Contains(e.v)) continue;//禁止回退
                    if (to.Select(u => stationList[u]).Where(u => u.Name == stationList[e.v].Name).Count() >= 2)//禁止复读
                        continue;
                    que.Push(new Node(e.v, node.value + e.val,new List<int>(to.ToArray())));
                }
            }
        }

        private void BuildRoute(int a,List<int> to)
        {
            List<Station> sta = new List<Station>();
            to.ForEach(u => sta.Add(stationList[u]));

            sta.Add(stationList[end]);
            /*
            for(int i = 0;i < sta.Count; i++)
            {
                Console.Out.Write($"{sta[i].Metro}{sta[i].Name},");
            }
            Console.Out.WriteLine();
            */
            List<Interval> ints = new List<Interval>();
            int b = 0;
            if (sta[0].Name == sta[1].Name) b = 1;
            for(int i = b + 1;i < sta.Count - 1; i++)
            {
                if (sta[i].Metro == sta[i - 1].Metro && sta[i].Metro == sta[i + 1].Metro) continue;
                if (b == -1) b = i;
                else
                {
                    ints.Add(new Interval(sta[b], sta[i]));
                    b = -1;
                }
            }
            if (b != -1)
            ints.Add(new Interval(sta[b], sta[sta.Count - 1]));
            //SAVE ALL INTERVALS
            SaveRoute(stationList[start].Id, stationList[end].Id, ints);
        }

        public void SaveRoute(string s,string e,List<Interval> route)
        {
            /*string rt = "[{" + route[0].begin + ":" + stationList[stationDic[route[0].begin]].Name + "," + route[0].end + ":" + stationList[stationDic[route[0].end]].Name + "}";
            for(int i = 1;i < route.Count; i++)
            {
                rt += ",{" + route[i].begin + ":" + stationList[stationDic[route[i].begin]].Name + "," + route[i].end + ":" + stationList[stationDic[route[i].end]].Name + "}";
            }
            rt += "]";
            Console.Out.Write($"From:{s} To:{e} \r\n{rt}\r\n");*/
            var pair = KeyValuePair.Create(s, e);
            if (!routeDic.ContainsKey(pair)) routeDic.Add(pair, new List<Route>());
            routeDic[pair].Add(new Route(route));
            routeDic[pair].Sort((a,b) => a.intervals.Count - b.intervals.Count);
        }
    }

    public struct Route
    {
        public List<Interval> intervals;
        public Route(List<Interval> i)
        {
            intervals = i;
        }
    };

    struct Edge
    {
        public int u, v, val;
        public Edge(int a,int b,int c)
        {
            u = a;
            v = b;
            val = c;
        }
    };

    struct Node
    {
        public int to,value;
        public List<int> from;
        public Node(int a, int b, List<int> c)
        {
            to = a;
            value = b;
            from = c;
        }
    };

    class PriorityQueue<T>
    {
        IComparer<T> comparer;
        T[] heap;

        public int Count { get; private set; }

        public PriorityQueue() : this(null) { }
        public PriorityQueue(int capacity) : this(capacity, null) { }
        public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }

        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }

        public void Push(T v)
        {
            if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
            heap[Count] = v;
            SiftUp(Count++);
        }

        public T Pop()
        {
            var v = Top();
            heap[0] = heap[--Count];
            if (Count > 0) SiftDown(0);
            return v;
        }

        public T Top()
        {
            if (Count > 0) return heap[0];
            throw new InvalidOperationException("优先队列为空");
        }

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }

        void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                if (comparer.Compare(v, heap[n2]) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }
    }

    class Comparer1 : IComparer<KeyValuePair<int, int>>
    {
        public int Compare([AllowNull] KeyValuePair<int, int> x, [AllowNull] KeyValuePair<int, int> y)
        {
            return x.Key - y.Key;
        }
    }

    class Comparer2 : IComparer<Node>
    {
        public int Compare([AllowNull] Node y, [AllowNull] Node x)
        {
            return x.value + KthShortest.dis[x.to] - (y.value + KthShortest.dis[y.to]);
        }
    }
}
