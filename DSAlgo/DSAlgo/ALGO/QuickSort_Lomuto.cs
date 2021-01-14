using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.ALGO
{
	/// <summary>
	/// 這裡是這個版本
	/// https://www.geeksforgeeks.org/quick-sort/
	///
	/// 但是實際上可以看到其他做法
	/// 所以QuickSort 是一個概念  pivot 可以設在最前  或最後  或其他地方
	/// 實作可以自由變化  關鍵相符即可
	/// 這個版本partition 很特別   是有一個i 從-1開始  找到比pivot小的  就往最左丟 丟完之後  下次要丟  i往右移一個  就不會動到被移到左邊的  所以雖然只做一邊  也有小左大右的效果
	/// 
	/// n
	/// n/2 n/2
	/// n/4 n/4 n/4 n/4
	/// T(n) = 2*T(n/2)+n
	/// 主定理  a=2 b=2  f() = n^1  , c=loga b= log2 2 = 1 = n^1
	/// 第二型   n^c log^k+1 n = nlogn
	/// --------
	/// 
	/// 看了gg文章 更精準
	///  T(n) = T(k) + T(n-k-1) + theta(n)
	/// Worst Case
	/// T(n) = T(n-1) + theta(n)  >  n+ n-1 + n-2 ... > O n^2
	///
	/// Best Case T(n) = 2T(n/2) + theta(n)  > theta nlogn
	/// 
	/// Average theta nlogn
	/// 
	/// 
	/// Although the worst case time complexity of QuickSort is O(n2) which is more than many other sorting algorithms like Merge Sort and Heap Sort, QuickSort is faster in practice, because its inner loop can be efficiently implemented on most architectures, and in most real-world data. QuickSort can be implemented in different ways by changing the choice of pivot, so that the worst case rarely occurs for a given type of data. However, merge sort is generally considered better when data is huge and stored in external storage.
	/// 
	/// Is QuickSort stable?
	/// The default implementation is not stable.However any sorting algorithm can be made stable by considering indexes as comparison parameter.
	/// 
	/// Is QuickSort In-place?
	/// As per the broad definition of in-place algorithm it qualifies as an in-place sorting algorithm as it uses extra space only for storing recursive function calls but not for manipulating the input.
	///
	/// 3-way QuickSort  解決大量重複元素  造成 n^2的問題
	/// a) arr[l..i] elements less than pivot.
	///	b) arr[i + 1..j - 1] elements equal to pivot.
	/// c) arr[j..r] elements greater than pivot.
	/// 相同元素的區塊  整個可以直接忽略掉  大幅加速
	/// 沒重複  best case nlogn
	/// 有重複  越多重複越減低時間   best case O n  線性時間  linear
	///  
	///  
	/// GG裡面寫得更多  厲害
	///
	/// 找到另一篇  就是用另外一種partition
	/// https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php
	/// 他是從左右兩邊向中間  分別找 大於 小於 pivot的  是用while持續推進到找到
	/// 然後左右swap
	///
	/// LC Sol 看到  Hoare's partition fails with duplicates, Lomuto's doesn't
	/// YT 看了幾部才找到   這部很詳細
	/// https://www.youtube.com/watch?v=v-1EGgaTFuw&t=633s
	/// 
	/// 
	/// </summary>
	class QuickSort
	{
		/* This function takes last element as pivot, 
	places the pivot element at its correct 
	position in sorted array, and places all 
	smaller (smaller than pivot) to left of 
	pivot and all greater elements to right 
	of pivot */
		static int partition(int[] arr, int low,
			int high)
		{
			int pivot = arr[high];

			// index of smaller element 
			int i = (low - 1);
			for (int j = low; j < high; j++)
			{
				// If current element is smaller 
				// than the pivot 
				if (arr[j] < pivot)
				{
					i++;

					// swap arr[i] and arr[j] 
					int temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}

			// swap arr[i+1] and arr[high] (or pivot) 
			int temp1 = arr[i + 1];
			arr[i + 1] = arr[high];
			arr[high] = temp1;

			return i + 1;
		}


		/* The main function that implements QuickSort() 
		arr[] --> Array to be sorted, 
		low --> Starting index, 
		high --> Ending index */
		static void quickSort(int[] arr, int low, int high)
		{
			if (low < high)
			{

				/* pi is partitioning index, arr[pi] is 
				now at right place */
				int pi = partition(arr, low, high);

				// Recursively sort elements before 
				// partition and after partition 
				quickSort(arr, low, pi - 1);
				quickSort(arr, pi + 1, high);
			}
		}
		
		// Driver program 
		public static void Run()
		{
			int[] arr = { 10, 7, 8, 9, 1, 5 };
			int n = arr.Length;
			quickSort(arr, 0, n - 1);
			Console.WriteLine("sorted array ");
			arr.Print();
		}

	}
}
