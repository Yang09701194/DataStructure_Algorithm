using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.Util
{
	public static class Shuffler
	{


		private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

		public static void Shuffle(int[] shuffleArr)
		{
			rnd = new Random(Guid.NewGuid().GetHashCode());

			for (int k = 0; k < shuffleArr.Length; k++)
			{
				//稍微改一下 去掉 i j 相同重取的可能性 直接 +1 以不重複
				// 就再進10%   336ms  81.78%
				// 應該主要差在這
				// 這種寫法都算是100%  只是誤差的快慢    320的解跑個幾次 也會變340
				int i = rnd.Next(shuffleArr.Length);
				int j = rnd.Next(shuffleArr.Length);
				if (i == j)
					j += 1;

				int temp = shuffleArr[i];
				shuffleArr[i] = shuffleArr[j];
				shuffleArr[j] = temp;
			}
		}


	}
}
