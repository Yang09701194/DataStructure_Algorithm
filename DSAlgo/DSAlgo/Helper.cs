using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSAlgo.DS;

namespace DSAlgo
{
	public static class Helper
	{


		public static void Print<T>(this IList<T> ls, string msg = "")
		{
			if (!string.IsNullOrEmpty(msg))
				Console.WriteLine(msg);
			Console.WriteLine(String.Join(" ", ls));
		}


		/// <summary>
		/// 策略說明
		/// https://github.com/alrightchiu/SecondRound/blob/master/content/Algorithms%20and%20Data%20Structures/Graph%20series/CC_fig/f5.png?raw=true
		/// 想像對這個圖  有多組SCC  要把每個SCC都轉成  set collapse
		/// 那就是先重置每個點的pred = -1
		/// 這樣子的話  就是先從數字小的點A開始  然後利用 adj list 得到直接與A相連的點  就是level1的tree node 所以他們的pred 就都設為level 0 的  接下來也很直覺  level1的node連接的lvl2的  pred都設定為lvl1的pred  不這樣想會覺得好像要跳級找  因為直接想從lvl2 推回lvl 0 中間隔一層  就沒那麼直接   但是上面那種進行方式就很直接可以想到就是這樣做
		/// 很明顯  因為是forest   所以每個Tree進行到一定步驟就會全部走完  然後pred都會設定為 >0的值
		/// 要找下一棵 還沒跑過的樹 很明顯就是對點foreach 找還是 -1的
		/// 那就來實做自己看過說明後原創的演算法看看是不是成功達成
		///
		/// 實際跑發現  上面的想法錯了
		/// 上面的想法如果是在tree上會是正確的
		/// 但如果圖有cycle  那每個 A>B>C cycle   B.pred=A C.pred=A A.pred會是C  這樣就不合SCC想要做的事
		/// SCC是要每個SCC 都抓一個root  而且他的pred 不是直接邊的關係父子的概念
		/// 而是DFS的 路徑   走出來後  的前後關係   這樣不是直接用邊能推的出來了
		/// 所以變成  要建立在DFS路徑上去推  才會得到正解
		/// 所以  方向這樣定  很直接就能找到解法
		/// 就是在原本的pred上面  每個點一直往前推pred  推到-1為止的點  就是collapse後的pred
		/// 
		/// </summary>
		public static void SetCollapsing(this Graph<int> _graph, int verticesCou, int[] predecessorArr)
		{
			//原本的錯誤想法   直接用邊的關係去推
			//for (int j = 0; j < verticesCou; j++)
			//	predecessor[j] = -1;
			//for (int j = 0; j < verticesCou; j++)
			//{
			//	if (predecessor[j] == -1)
			//	{
			//		var adjVertices = _graph.AdjacencyList[j];
			//		foreach (int adjVertex in adjVertices)
			//		{
			//			if (predecessor[adjVertex] == -1)
			//				predecessor[adjVertex] = j;
			//		}
			//	}
			//}

			var origPred = predecessorArr.ToArray();

			//正確
			for (int i = 0; i < verticesCou; i++)
			{
				int predecessor = origPred[i];
				while (predecessor != -1 && origPred[predecessor] != -1)
				{
					predecessor = origPred[predecessor];
				}
				predecessorArr[i] = predecessor;
			}

		}

	}

}
