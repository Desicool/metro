using metro.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace metro.Initialize
{
    public class KthShortest
    {
        private static readonly Dictionary<string, int> stationDic = new Dictionary<string, int>();
        private static readonly List<Station> stationList = new List<Station>();
        private static readonly List<string> stations = new List<string>();
        private static readonly List<List<Edge>> edges = new List<List<Edge>>();
        public static List<int> dis = new List<int>();
        private static List<int> from = new List<int>();
        private static List<int> to = new List<int>();
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
                    to.Add(index);
                }
                );
                for (int i = 1; i < stas.Count(); i++)
                {
                    edges[stationDic[stas[i - 1].Id]].Add(new Edge(stationDic[stas[i - 1].Id],stationDic[stas[i].Id],1));
                    edges[stationDic[stas[i].Id]].Add(new Edge(stationDic[stas[i].Id],stationDic[stas[i - 1].Id],1));
                }
            }
            );
            var transferStaions = TransferStation.transferStationList;
            transferStaions.ForEach(x =>
            {
                for (int i = 0; i < x.Count(); i++)
                {
                    for (int j = 0; j < x.Count(); j++)
                    {
                        if (i == j) continue;
                        edges[stationDic[x[i]]].Add(new Edge(stationDic[x[i]],stationDic[x[j]],0));
                    }
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
                    if (stationList[i].Metro == stationList[j].Metro)
                    {
                        Interval route = new Interval(stationList[i].Id, stationList[j].Id);
                        SaveRoute(stationList[i].Id, stationList[j].Id,new List<Interval> { route });
                    }
                    else
                    {
                        start = i;
                        for (int x = 0; x < stationList.Count; x++)
                        {
                            to[x] = x;
                        }
                        BFS(i);
                    }
                }
            }
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
            que.Push(new Node(a, 0));
            while (que.Count > 0)
            {
                Node node = que.Top();
                que.Pop();
                if (node.to == end)
                {//到达终点次数
                    BuildRoute(a);
                    k--;
                    if (k == 0)
                    {
                        return;
                    }
                }
                for (int i = 0; i < edges[node.to].Count(); i++)
                {//扩散（跑反向边）
                    var e = edges[node.to][i];
                    to[e.v] = node.to;
                    que.Push(new Node(e.v, node.value + e.val));
                }
            }
        }

        private void BuildRoute(int a)
        {
            List<Station> sta = new List<Station>();
            int t = a;
            while(a != start)
            {
                sta.Add(stationList[a]);
                a = to[a];
            }
            sta.Add(stationList[start]);
            sta.Reverse();
            a = from[t];
            while(a != end)
            {
                sta.Add(stationList[a]);
                a = from[a];
            }
            sta.Add(stationList[end]);
            List<Interval> ints = new List<Interval>();
            int b = 0;
            for(int i = 1;i < sta.Count - 1; i++)
            {
                if (sta[i].Metro == sta[i - 1].Metro && sta[i].Metro == sta[i + 1].Metro) continue;
                if (b == -1) b = i;
                else
                {
                    ints.Add(new Interval(sta[b].Id, sta[i].Id));
                    b = -1;
                }
            }
            ints.Add(new Interval(sta[b].Id, sta[sta.Count - 1].Id));
            //SAVE ALL INTERVALS
            SaveRoute(stationList[start].Id, stationList[end].Id, ints);
        }

        public void SaveRoute(string s,string e,List<Interval> route)
        {
            Console.Out.Write("From:" + s + " To:" + e + route);
        }
    }

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
        public Node(int a, int b)
        {
            to = a;
            value = b;
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
        public int Compare([AllowNull] Node x, [AllowNull] Node y)
        {
            return x.value + KthShortest.dis[x.to] - (y.value + KthShortest.dis[y.to]);
        }
    }
}
