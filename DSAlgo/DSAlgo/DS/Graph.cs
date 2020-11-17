using System;using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSAlgo.DS
{
	public class Graph<T>
	{
		public Graph() { }

		private IEnumerable<T> _vertices;
		private IEnumerable<Tuple<T, T>> _edges; 

		public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges, GraphOption option)
		{
			_vertices = vertices;
			_edges = edges;
			//	點和線要完全分開也是很聰明的做法
			foreach (T vertex in vertices)
				AddVertex(vertex);
			foreach (var edge in edges)
				AddEdge(edge, option);
			//但是還是能在無知的情況下去搜尋才是正道   跟Dijkstra Shortest Path 有點像
			//不知道所有點的情況下   去構建出來   等於是創造一個通用演算法 
			//也不是這樣說
			//實際上就算是手繪解 給你一個圖出來  也是要已知所有的點線  所以其實應該已經知道
			//原本想的可能例如現實世界的地圖   或者那種超大地圖  就會想像是從一個點往外延伸
			//但是其實  還是先已知圖  演算法才去分析
			//所以實際程式是分兩個動作  1 建構圖成資結  2 跑演算法
			//直接解紙本考題  會以為只有跑演算法的部分  就會以為全部都是邊探索邊得出的
			//而忽略了 1 的事實
		}

		public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

		public void AddVertex(T vertex)
		{ 
			AdjacencyList[vertex] = new HashSet<T>();
		}

		public void AddEdge(Tuple<T, T> edge, GraphOption option)
		{
			switch (option)
			{
				case GraphOption.Undirected:
					if (AdjacencyList.ContainsKey(edge.Item1)
					    && AdjacencyList.ContainsKey(edge.Item2)
					)
					{
						AdjacencyList[edge.Item1].Add(edge.Item2);
						AdjacencyList[edge.Item2].Add(edge.Item1);
					}
					return;
				case GraphOption.Diirected:
					if (AdjacencyList.ContainsKey(edge.Item1)
					    && AdjacencyList.ContainsKey(edge.Item2)
					)
					{
						AdjacencyList[edge.Item1].Add(edge.Item2);
					}
					return;
				case GraphOption.Transpose:
					if (AdjacencyList.ContainsKey(edge.Item1)
					    && AdjacencyList.ContainsKey(edge.Item2)
					)
					{
						//	方向倒過來
						AdjacencyList[edge.Item2].Add(edge.Item1);
					}
					return;
					return;
				default:
					throw new Exception("option not valid");
			}

		}


		public Graph<T> GetTranspose()
		{
			Graph<T> gT = new Graph<T>(_vertices, _edges, GraphOption.Transpose);
			return gT;
		}

		public int VerticesCount
		{
			get { return _vertices.Count(); }
		}
	}

	public enum GraphOption
	{
		Diirected,
		Undirected,
		Transpose
	}
}
