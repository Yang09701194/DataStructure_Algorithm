using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.ALGO
{

	/// <summary>
	/// https://www.geeksforgeeks.org/hoares-vs-lomuto-partition-scheme-quicksort/
	/// 詳細討論見  Lomuto
	/// </summary>
	class QuickSort_Hoare_s
	{


			/* This function takes first element as pivot, and
			places all the elements smaller than the pivot on the
			left side and all the elements greater than the pivot
			on the right side. It returns the index of the last
			element on the smaller side*/
			static int partition(int[] arr, int low, int high)
			{
				int pivot = arr[low];
				int i = low - 1, j = high + 1;

				while (true)
				{
					// Find leftmost element greater
					// than or equal to pivot
					do
					{
						i++;
					} while (arr[i] < pivot);

					// Find rightmost element smaller
					// than or equal to pivot
					do
					{
						j--;
					} while (arr[j] > pivot);

					// If two pointers met.
					if (i >= j)
						return j;
					int temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
					// swap(arr[i], arr[j]);
				}
			}

			/* The main function that
			implements QuickSort
			arr[] --> Array to be sorted,
			low --> Starting index,
			high --> Ending index */
			static void quickSort(int[] arr, int low, int high)
			{
				if (low < high)
				{
					/* pi is partitioning index,
					arr[p] is now at right place */
					int pi = partition(arr, low, high);

					// Separately sort elements before
					// partition and after partition
					quickSort(arr, low, pi);
					quickSort(arr, pi + 1, high);
				}
			}

			/* Function to print an array */
			static void printArray(int[] arr, int n)
			{
				for (int i = 0; i < n; i++)
					Console.Write(" " + arr[i]);
				Console.WriteLine();
			}

			// Driver Code
			static public void Run()
			{
				int[] arr = { 10, 7, 8, 9, 1, 5 };
				int n = arr.Length;
				quickSort(arr, 0, n - 1);
				Console.WriteLine("Sorted array: ");
				printArray(arr, n);
			}

	}
}
