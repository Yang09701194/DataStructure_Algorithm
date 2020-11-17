using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.ALGO
{
	class Sort_QuickSort
	{

		/// <summary>
		///
		/// 這個的用途是說   vec是點的值  vec2是點的編號
		/// 所以用 vec 排序  的順序對 vec2應用   就會得到編號的排序	
		/// 
		/// 矩陣 finishLargetoSmall[] 用來儲存 finish[] 由大至小的vertex順序
		/// int[] finishLargetoSmall = new int[num_vertex];
		///	for (int i = 0; i 小於 num_vertex; i++
		/// {
		///	finishLargetoSmall[i] = i;
		/// }
		/// QuickSort()會更新 finishLargetoSmall[] 成 finish[] 由大至小的vertex順序
		/// Sort_QuickSort.QuickSort(dfs.finish, 0, num_vertex - 1, finishLargetoSmall);
		/// </summary>
		/// <param name="vec"></param>
		/// <param name="front"></param>
		/// <param name="end"></param>
		/// <param name="vec2"></param>

		public static void QuickSort(int[] vec, int front, int end, int[] vec2)
		{

			if (front < end)
			{
				int pivot = Partition(vec, front, end, vec2);
				QuickSort(vec, front, pivot - 1, vec2);
				QuickSort(vec, pivot + 1, end, vec2);
			}

		}

		public static int Partition(int[] vec, int front, int end, int[] vec2)
		{
			int pivot = vec[end];
			int i = front - 1;
			for (int j = front; j < end; j++)
			{
				if (vec[j] > pivot)
				{
					i++;	//把大的一直搬到前面
					swap(ref vec[i], ref vec[j]);
					swap(ref vec2[i], ref vec2[j]);
				}
			}
			swap(ref vec[i + 1], ref vec[end]);
			swap(ref vec2[i + 1], ref vec2[end]);

			return i + 1;   // 把 i + 1 當成下一個 recurrsive call 的 中間斷點
		}

		public static void swap(ref int x, ref int y)
		{
			int temp = x;
			x = y;
			y = temp;
		}



	}

}
