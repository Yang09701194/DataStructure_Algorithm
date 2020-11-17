using System;
using System.Collections.Generic;
using System.Text;
using DSAlgo.DS;

namespace DSAlgo.ALGO
{
	/// <summary>
	/// The Time complexity of both BFS and DFS will be O(V + E), where V is the number of vertices, and E is the number of Edges. This again depends on the data strucure that we user to represent the graph. If it is an adjacency matrix, it will be O(V^2) . If we use an adjacency list, it will be O(V+E). Now , to explain how, lets us consider the difference between a sparsely connected graph and a densely connected graph.
	/// 
	/// https://alrightchiu.github.io/SecondRound/graph-depth-first-searchdfsshen-du-you-xian-sou-xun.html
	/// Depth-First Search(DFS，深度優先搜尋)的核心精神便如同Pre-Order Traversal
	/// 這個就厲害了  我學 Pre Order 那麼久 從來不會想到他跟DFS  是一樣的
	///
	/// 由以上說明可以觀察出，DFS()本質上是一種「遞迴(recursion)結構」，而遞迴結構其實是利用了系統的「堆疊(stack)」，因此，這兩種方式皆能實現DFS()，以下提供的範例程式碼將以遞迴形式完成。
	/// </summary>
	class DFS_Algo
	{
		//  他這邊有點有趣   他又另外寫了一個Graph 跟 BFS 類似  但是資料結構不是Dic + HashSet 而是 vector + List 都C++   可能只是單純換一下而已  練個手感吧

		//  再繼續看  演算法推導過程步驟看起來很複雜  但是code寫起來感覺簡單許多

		int verticesCou;
		public int[] color, discover, finish, predecessor;
		private Graph<int> _graph;

		public void DFS(int start, Graph<int>  graph)
		{
			_graph = graph;
			verticesCou = graph.VerticesCount;
			color = new int[verticesCou];
			discover = new int[verticesCou];
			finish = new int[verticesCou];
			predecessor = new int[verticesCou];

			for (int j = 0; j < predecessor.Length; j++)
			{
				predecessor[j] = -1;
			}

			int time = 0;

			DFS_Visit(start, ref time, graph);// 第一個先跑start
			for (int j = 0; j < verticesCou; j++)
			{
				if (color[j] == 0)
				{
					DFS_Visit(j, ref time, graph);//然後每個點都跑一次
				}
			}

		}



		public void DFS_WithOrder(int start, Graph<int> graph, int[] vertexOrder)
		{
			_graph = graph;
			verticesCou = graph.VerticesCount;
			color = new int[verticesCou];
			discover = new int[verticesCou];
			finish = new int[verticesCou];
			predecessor = new int[verticesCou];

			for (int j = 0; j < predecessor.Length; j++)
			{
				predecessor[j] = -1;
			}

			int time = 0;
			for (int j = 0; j < verticesCou; j++)
			{
				if (color[vertexOrder[j]] == 0)
				{
					DFS_Visit(vertexOrder[j], ref time, graph);
				}
			}

		}


		private void DFS_Visit(int vertex, ref int time, Graph<int> graph)
		{
			color[vertex] = 1;	//	塗成灰色
			discover[vertex] = ++time;

			var vertexAdjList = graph.AdjacencyList[vertex];
			foreach (int adjV in vertexAdjList)
			{
				if (color[adjV] == 0)
				{
					predecessor[adjV] = vertex;
					DFS_Visit(adjV, ref time, graph);
				}
			}

			color[vertex] = 2;//  塗成黑色
			finish[vertex] = ++time;//這樣子寫起來感覺就跟 leetcode 有點像  就是說想的時候是很複雜的  實現起來的程式碼相對簡單許多  簡單的程式碼就可以形成複雜的流程

		}


		public void SetCollapsing()
		{
			_graph.SetCollapsing(verticesCou, predecessor);
		}

		public int GetPredecessor(int i)
		{
			return predecessor[i];
		}


		public void PrintInfo()
		{
			Console.WriteLine("color");
			color.Print();
			Console.WriteLine("discover");
			discover.Print();
			Console.WriteLine("finish");
			finish.Print();
			Console.WriteLine("predecessor");
			predecessor.Print();
		}



		public static void main()
		{
			DFS_Algo dfs = new DFS_Algo();
			var vertices = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
			var edges = new[]{Tuple.Create(0,1), Tuple.Create(0,2), Tuple.Create(1,3), Tuple.Create(2,1), Tuple.Create(2,5), Tuple.Create(3,4), Tuple.Create(3,5), Tuple.Create(5,1), Tuple.Create(6,4), Tuple.Create(6,7), Tuple.Create(7,6)};
			var graph = new Graph<int>(vertices, edges, GraphOption.Diirected);
			dfs.DFS(0, graph);
			dfs.PrintInfo();

			//想了很久總算可能想出為什麼  跑的結果  和 文章不一樣
			//應該是因為  BFS的時候  例子是 無向圖 undirected graph
			// graph的Add Edge方法也是針對無向圖設計的
			//  所以要再增加能接受有向圖的機制

			//  已加  推測沒錯  加了就成功了
		}

		//若discover[X] 比discover[Y]大，而且finish[X] 比finish[Y]小，表示vertex(X)比vertex(Y)較晚「被發現」，而且較早「結束」，則vertex(X)必定是vertex(Y)的descendant。
		//以vertex(E)與vertex(A)為例，vertex(E)的「搜尋生命週期」完全在vertex(A)的「搜尋生命週期」之內，因此vertex(E)必定是vertex(A)的descendant。
		//相反，若discover[X] 比discover[Y]小，而且finish[X] 比finish[Y]大，表示vertex(X)比vertex(Y)較早「被發現」，而且較晚「結束」，則vertex(X)必定是vertex(Y)的ancestor。
		//以vertex(B)與vertex(F)為例，vertex(B)的「搜尋生命週期」完全包覆住vertex(F)的「搜尋生命週期」，因此vertex(B)必定是vertex(F)的ancestor。
		//第三種情形，若兩個vertex的「搜尋生命週期」完全沒有重疊，那麼這兩個vertex在Depth-First Forest中：
		//有可能在同一棵Depth-First Tree，但是互相沒有「ancestor-descendant」的關係，例如vertex(D)與vertex(C)。此時，discover[D]<discover[C]，而且finish[D]<finish[C]
		//也有可能在不同棵Depth-First Tree，例如vertex(C)與vertex(H)。此時，discover[C]<discover[H]，而且finish[C]<finish[H]。



		//Tree edge：若vertex(Y)是被vertex(X)「發現」，則edge(X, Y)即為Tree edge，也就是Depth-First Tree中的edge。
		//透過顏色判斷edge：當vertex(X)搜尋到vertex(Y)，且vertex(Y)為「白色」時，就會建立出Tree edge。
		//Back edge：所有指向ancestor的edge，稱為Back edge。如圖六中，edge(F, B)與edge(H, G)。
		//透過顏色判斷edge：當vertex(X)搜尋到vertex(Y)，且vertex(Y)為「灰色」，就會建立起Back edge，見圖三(j)、圖三(q)與圖六。
		//Forward edge：所有指向descendant但不是Tree edge的edge，稱為Forward edge。觀察「時間軸」，若Graph存在例如：edge(A, D)、edge(A, E)或者edge(B, E)，即可稱之為Forward edge。很遺憾的，圖六中，沒有Forward edge。
		//透過顏色判斷edge：當vertex(X)搜尋到vertex(Y)時，vertex(Y)為「黑色」，並且discover[X]<discover[Y]，edge(X, Y)即為Forward edge。
		//Cross edge：若兩個vertex不在同一棵Depth-First Tree上，例如vertex(C)與vertex(H)，或者兩個vertex在同一棵Depth-First Tree上卻沒有「ancestor-descendant」的關係，例如vertex(C)與vertex(F)，則稱連結此兩個vertex的edge為Cross edge。
		//透過顏色判斷edge：當vertex(X)搜尋到vertex(Y)時，vertex(Y)為「黑色」，並且discover[X]>discover[Y]，edge(X, Y)即為Cross edge。


	}
}
