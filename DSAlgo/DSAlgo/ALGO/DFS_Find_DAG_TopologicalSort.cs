using System;
using System.Collections.Generic;
using System.Text;
using DSAlgo.DS;

namespace DSAlgo.ALGO
{
	class DFS_Find_DAG_TopologicalSort
	{

		/// <summary>
		/// http://alrightchiu.github.io/SecondRound/graph-li-yong-dfsxun-zhao-dagde-topological-sorttuo-pu-pai-xu.html
		/// </summary>
		public static void TopologicalSort(int start, Graph<int> graph)
		{
			int num_vertex = graph.VerticesCount;

			// 第一次DFS(), 目的是取得finish[]
			DFS_Algo dfs = new DFS_Algo();
			dfs.DFS(start, graph);
			// 顯示 第一次DFS()後的finish[]
			Console.WriteLine("First DFS() on G, finish time:");
			dfs.finish.Print("finish");

			// 矩陣 finishLargetoSmall[] 用來儲存 finish[] 由大至小的vertex順序
			int[] finishLargetoSmall = new int[num_vertex];
			for (int i = 0; i < num_vertex; i++)
			{
				finishLargetoSmall[i] = i;
			}
			// QuickSort()會更新 finishLargetoSmall[] 成 finish[] 由大至小的vertex順序
			Sort_QuickSort.QuickSort(dfs.finish, 0, num_vertex - 1, finishLargetoSmall);

			// 列印出 finish[] 由大至小的vertex順序
			Console.WriteLine("Topological Sort:");
			Console.WriteLine("finish time Large to Small:");
			finishLargetoSmall.Print();
		}

		public static void main()
		{
			var vers = new List<int>();
			for (int i = 0; i < 15; i++)
				vers.Add(i);
			int[] verticies = vers.ToArray(); 

			Graph<int> graph = new Graph<int>(
				verticies, new List<Tuple<int, int>>()
				{
					 new Tuple<int, int>(0,2),
					 new Tuple<int, int>(1,2),
					 new Tuple<int, int>(2,6),
					 new Tuple<int, int>(2,7),
					 new Tuple<int, int>(3,4),
					 new Tuple<int, int>(4,5),
					 new Tuple<int, int>(5,6),
					 new Tuple<int, int>(5,14),
					 new Tuple<int, int>(6,8),
					 new Tuple<int, int>(6,9),
					 new Tuple<int, int>(6,11),
					 new Tuple<int, int>(6,12),
					 new Tuple<int, int>(7,8),
					 new Tuple<int, int>(9,10),
					 new Tuple<int, int>(12,13),
				}
				, GraphOption.Diirected
				);

			DFS_Find_DAG_TopologicalSort.TopologicalSort(0, graph);
			DFS_Find_DAG_TopologicalSort.TopologicalSort(4, graph);
		}




	}
}
