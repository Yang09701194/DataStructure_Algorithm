using System;
using System.Collections.Generic;
using System.Text;
using DSAlgo.DS;

namespace DSAlgo.ALGO
{
	/// <summary>
	/// The Time complexity of both BFS and DFS will be O(V + E), where V is the number of vertices, and E is the number of Edges. This again depends on the data strucure that we user to represent the graph. If it is an adjacency matrix, it will be O(V^2) . If we use an adjacency list, it will be O(V+E). Now , to explain how, lets us consider the difference between a sparsely connected graph and a densely connected graph.
	/// 
	/// 因為時間複雜度  Adj List 太重要了
	/// 所以程式碼一定用 Adj List
	/// 那就是步驟如下
	/// 1	把G轉成Adj List
	/// 2	就可以餵給寫好的BFS   end
	///
	/// BFS 概念都直接看YT上最有名那個  秒懂
	///
	/// Adjacency是相鄰的意思
	/// https://www.koderdojo.com/blog/breadth-first-search-and-shortest-path-in-csharp-and-net-core
	/// </summary>
	class BFS_Algo
	{

		public HashSet<T> BFS<T>(Graph<T> graph, T start)
		{
			var visisted = new HashSet<T>();

			if (!graph.AdjacencyList.ContainsKey(start))
				return visisted;

			var queue = new Queue<T>();
			queue.Enqueue(start);
			while (queue.Count > 0)
			{
				var vertex = queue.Dequeue();
				//這裡可以看出  HashSet非必要  可以用其他結構  沒有用到HashSet Add不重複的特性
				if (visisted.Contains(vertex))
					continue;

				visisted.Add(vertex);

				foreach (T neighbor in graph.AdjacencyList[vertex])
				{
					if(!visisted.Contains(neighbor))
						queue.Enqueue(neighbor);
				}
			}

			//實際寫起來就很抽象  就很有圖論的感覺  就是說  寫起來會有一種眼前有無數種延伸的各種可能性
			//想出了一個方法  好像看起來都能滿足很多可觀察的特性 
			//但唯一怕的就是一點  就是可能只達成了大部分  而不是全部  例如80% 非100%
			//跟LeetCode 解題一樣   可能解決了80%的Test Case  但就是少到20%
			//然後就會連結到 真的要確定完整  就要 證明

			return visisted;
		}

		public static void main()
		{
			//var vertices = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			//var edges = new[] {Tuple.Create(1,2), Tuple.Create(1,3), Tuple.Create(2,4 ),Tuple.Create(3,5 ),Tuple.Create(3, 6),Tuple.Create(4, 7),Tuple.Create(5, 7),Tuple.Create(5, 8),Tuple.Create(5, 6),Tuple.Create(8, 9),Tuple.Create(9, 10)};

			//var graph = new Graph<int>(vertices, edges);
			//var bfs = new BFS_Algo();
			//var bfsVertices = bfs.BFS(graph, 1);
			//Console.WriteLine(String.Join(" ", bfsVertices));

			////Start Level 0: 1
			////Traverse Level 1: 2, 3
			////Traverse Level 2: 4, 5, 6
			////Traverse Level 3: 7, 8
			////Traverse Level 4: 9, 10


			////厲害  確實跟YT的順序一樣
			//var vertices = new string[] {"A", "B", "S", "C", "D", "F", "G", "E", "H"};
			//var edges = new [] {Tuple.Create("A","B"), Tuple.Create("A", "S"), Tuple.Create("S", "C"), Tuple.Create("C", "D"), Tuple.Create("C", "E"), Tuple.Create("C", "F"), Tuple.Create("S", "G"), Tuple.Create("F", "G"), Tuple.Create("G", "H"), Tuple.Create("H", "E") };
			//var graph = new Graph<string>(vertices, edges);
			//var bfs = new BFS_Algo();
			//var bfsVertices = bfs.BFS(graph, "A");
			//Console.WriteLine(String.Join(" ", bfsVertices));


			// S P
			var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
				Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
				Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
				Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10), Tuple.Create(8, 10)};

			var graph = new Graph<int>(vertices, edges, GraphOption.Undirected);
			var algorithms = new BFS_Algo();

			var startVertex = 1;
			var shortestPath = algorithms.BFS_ShortestPath(graph, startVertex);
			foreach (var vertex in vertices)
				Console.WriteLine("shortest path to {0,2}: {1}",
					vertex, string.Join(", ", shortestPath(vertex)));

			//# shortest path to  1: 1
			//# shortest path to  2: 1, 2
			//# shortest path to  3: 1, 3
			//# shortest path to  4: 1, 2, 4
			//# shortest path to  5: 1, 3, 5
			//# shortest path to  6: 1, 3, 6
			//# shortest path to  7: 1, 2, 4, 7
			//# shortest path to  8: 1, 3, 5, 8
			//# shortest path to  9: 1, 3, 5, 8, 9
			//# shortest path to 10: 1, 3, 5, 8, 9, 10

		}


		public Func<T, IEnumerable<T>> BFS_ShortestPath<T>(Graph<T> graph, T start)
		{
			var previous = new Dictionary<T, T>();

			var queue = new Queue<T>();
			queue.Enqueue(start);

			while (queue.Count > 0)
			{
				var vertex = queue.Dequeue();
				foreach (var neighbor in graph.AdjacencyList[vertex])
				{
					if (previous.ContainsKey(neighbor))
						continue;

					//  這邊想了一段時間才理解  能這樣做  跟Adj List的特性有關
					//  特性  左邊一個點   隊到右邊一個集合  由直接相鄰的點組成
					//  所以右邊任一點  都會是左點在BFS延伸出去的
					//	這裡再加入  考研的時候 考題提到的   如果遇到迴圈怎麼辦
					//  依照前面想BFS看到的圖  避免的方式就是  用visited紀錄到訪過的一點
					// 如果每個點都只到訪一次  那就不可能形成cycle  因為相當於所有的邊只有一條邊連到那個點  而cycle形成的要件是  至少要兩個邊連到那個點
					//  又依照累積學習的經驗 沒cycle  = tree  所以可以用tree去想
					// 如果是用Tree反推  那就很直接了  往回返的路徑只會有一條  子往父一直找
					//  而且路徑長度就是level高度  都很直接的答案
					previous[neighbor] = vertex;
					queue.Enqueue(neighbor);
				}
			}

			Func<T, IEnumerable<T>> shortestPath = v =>
			{
				var path = new List<T>();
				var current = v;
				while (!current.Equals(start))
				{
					path.Add(current);
					current = previous[current];
				}

				path.Add(start);
				path.Reverse();

				return path;
			};

			return shortestPath;
		}



		//  他最後還有一個BFS的改編版本

		//Tracing the Path of Breadth-First Search in C#
		//If you want a list of the vertices as they are visited by breadth-first search, just add each vertex one-by-one to a list.Here is breadth-first search with an extra parameter, preVisit, which allows one to pass a function that gets called each time a vertex is visited.

		//  但是只是在BFS 多傳入一個Action  可以外部決定當訪問到一個點時  要加上什麼動作
		//  這只是一般改寫    和Algo本身沒關係   所以我就不放  需要可以去看

		// BFS (Breadth First Search) is also used in different situations. These are like below −
		// 
		// In peer-to-peer network like bit-torrent, BFS is used to find all neighbor nodes
		// Search engine crawlers are used BFS to build index. Starting from source page, it finds all links in it to get new pages
		// Using GPS navigation system BFS is used to find neighboring places.
		// In networking, when we want to broadcast some packets, we use the BFS algorithm.
		// Path finding algorithm is based on BFS or DFS.
		// BFS is used in Ford-Fulkerson algorithm to find maximum flow in a network.

		// Difference between BFS and DFS
		// Sr. No.	Key	BFS	DFS
		// 1	Definition	BFS, stands for Breadth First Search.	DFS, stands for Depth First Search.
		// 2	Data structure	BFS uses Queue to find the shortest path.	DFS uses Stack to find the shortest path.
		// 3	Source	BFS is better when target is closer to Source.	DFS is better when target is far from source.
		// 4	Suitablity for decision tree	As BFS considers all neighbour so it is not suitable for decision tree used in puzzle games.	DFS is more suitable for decision tree. As with one decision, we need to traverse further to augment the decision. If we reach the conclusion, we won.
		// 5	Speed	BFS is slower than DFS.	DFS is faster than BFS.
		// 6	Time Complexity	Time Complexity of BFS = O(V+E) where V is vertices and E is edges.	Time Complexity of DFS is also O(V+E) where V is vertices and E is edges.


	}

}
