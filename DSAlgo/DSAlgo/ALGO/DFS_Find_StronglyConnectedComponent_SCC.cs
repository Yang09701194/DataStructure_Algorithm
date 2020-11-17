using System;
using System.Collections.Generic;
using System.Text;
using DSAlgo.DS;

namespace DSAlgo.ALGO
{
	class DFS_Find_StronglyConnectedComponent_SCC
	{

		/// <summary>
		/// http://alrightchiu.github.io/SecondRound/graph-li-yong-dfsxun-zhao-strongly-connected-componentscc.html#ref
		/// </summary>
		public static void PrintSCCs(int start, Graph<int> graph)
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
			Console.WriteLine("finish time Large to Small:");
			finishLargetoSmall.Print();


			// gT代表Transpose of Graph
			var gT = graph.GetTranspose();

			// 第二次DFS(), 執行在gT
			DFS_Algo dfsGT = new DFS_Algo();
			dfsGT.DFS_WithOrder(start, gT, finishLargetoSmall);

			// 顯示 第二次DFS()後的finish[]
			Console.WriteLine("Second DFS() on gT, finish time:\n");
			dfsGT.finish.Print("finish");
			// 顯示 第二次DFS()後的predecessor[]
			Console.WriteLine("predecessor[] before SetCollapsing:\n");
			dfsGT.predecessor.Print("predecessor");

			dfsGT.SetCollapsing();
			//這個有點沒品  他竟然沒有附  SetCollapsing  的程式碼
			//http://alrightchiu.github.io/SecondRound/graph-li-yong-dfshe-bfsxun-zhao-connected-component.html
			//原文是有圖說解釋得很詳細   簡單來說  把一個圖的所有點   改變成直接連結到Root
			//看來是出作業自己寫
			//不過找到這篇有類似的程式碼  http://alrightchiu.github.io/SecondRound/setyi-arraybiao-shi.html
			//來參考看看
			//實際想想看，這邊使用的機制 就是 Adj List   所以就要用AdjList的概念做法來做到
			//那就主要是  刪除邊  增加邊   還有把predecessor設定為root
			//predecessor隔天起來就忘記   他也就是上一層的父節點  就是DFS 一點走到下個點 一點就是下點的pred
			//所以就是一個點對一個pred  也就是dfs類中的那個array啦


			// 顯示 SetCollapsing後的predecessor[]
			Console.WriteLine("predecessor after SetCollapsing:\n");
			dfsGT.predecessor.Print("predecessor");

			// 如同在undirected graph中尋找connected component
			int num_cc = 0;
			for (int i = 0; i < num_vertex; i++)
			{
				if (dfsGT.GetPredecessor(i) < 0)
				{
					Console.WriteLine($"SCC#{++num_cc}: {i} ");
					for (int j = 0; j < num_vertex; j++)
					{
						if (dfsGT.GetPredecessor(j) == i)
						{
							Console.WriteLine(j + " ");
						}
					}
				}
			}
		}

		public static void main()
		{ 
			 Graph<int> graph = new Graph<int>(
				 new int[]{0, 1,2,3,4,5,6,7,8}, new List<Tuple<int, int>>()
				 {
					 new Tuple<int, int>(0,1),
					 new Tuple<int, int>(1,2),
					 new Tuple<int, int>(1,4),
					 new Tuple<int, int>(2,0),
					 new Tuple<int, int>(2,3),
					 new Tuple<int, int>(2,5),
					 new Tuple<int, int>(3,2),
					 new Tuple<int, int>(4,5),
					 new Tuple<int, int>(4,6),
					 new Tuple<int, int>(5,4),
					 new Tuple<int, int>(5,6),
					 new Tuple<int, int>(5,7),
					 new Tuple<int, int>(6,7),
					 new Tuple<int, int>(7,8),
					 new Tuple<int, int>(8,6),
				 }
				 , GraphOption.Diirected
				 );

			 DFS_Find_StronglyConnectedComponent_SCC.PrintSCCs(0, graph);
		}

	}
}
