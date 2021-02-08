using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.DS
{

	/// <summary>
	///
	/// Time Complexity of HashSet Operations: The underlying data structure for HashSet is hashtable. So amortize (average or usual case) time complexity for
	/// add, remove and look-up (contains method) operation of HashSet takes O(1) time.
	///
	/// 
	/// </summary>
	class TestHashSet
	{

		public static void Test()
		{
			HashSet<int> evenNumbers = new HashSet<int>();
			HashSet<int> oddNumbers = new HashSet<int>();

			var b = evenNumbers.Add(2);
			b = evenNumbers.Add(2);
			b = evenNumbers.Add(2);


			for (int i = 0; i < 5; i++)
			{
				// Populate numbers with just even numbers.
				evenNumbers.Add(i * 2);

				// Populate oddNumbers with just odd numbers.
				oddNumbers.Add((i * 2) + 1);
			}

			Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
			DisplaySet(evenNumbers);

			Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
			DisplaySet(oddNumbers);

			// Create a new HashSet populated with even numbers.
			HashSet<int> numbers = new HashSet<int>(evenNumbers);
			Console.WriteLine("numbers UnionWith oddNumbers...");
			numbers.UnionWith(oddNumbers);

			Console.Write("numbers contains {0} elements: ", numbers.Count);
			DisplaySet(numbers);

			void DisplaySet(HashSet<int> collection)
			{
				Console.Write("{");
				foreach (int i in collection)
				{
					Console.Write(" {0}", i);
				}
				Console.WriteLine(" }");
			}

			/* This example produces output similar to the following:
			* evenNumbers contains 5 elements: { 0 2 4 6 8 }
			* oddNumbers contains 5 elements: { 1 3 5 7 9 }
			* numbers UnionWith oddNumbers...
			* numbers contains 10 elements: { 0 2 4 6 8 1 3 5 7 9 }
			*/


			Console.WriteLine("Add again test unique property");
			for (int i = 0; i < 5; i++)
			{
				// Populate numbers with just even numbers.
				evenNumbers.Add(i * 2);

				// Populate oddNumbers with just odd numbers.
				oddNumbers.Add((i * 2) + 1);
			}
			Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
			DisplaySet(evenNumbers);

			Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
			DisplaySet(oddNumbers);

		}

	}
}
