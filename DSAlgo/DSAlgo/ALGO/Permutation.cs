﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo.ALGO
{


	/// <summary>
	/// https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
	/// </summary>
	class Permutation
	{
		private static void Swap(ref char a, ref char b)
		{
			if (a == b) return;

			var temp = a;
			a = b;
			b = temp;
		}

		public static void GetPer(char[] list)
		{
			int x = list.Length - 1;
			GetPer(list, 0, x);
		}

		private static void GetPer(char[] list, int k, int m)
		{
			if (k == m)
			{
				Console.WriteLine(list);
			}
			else
				for (int i = k; i <= m; i++)
				{
					Swap(ref list[k], ref list[i]);
					GetPer(list, k + 1, m);
					Swap(ref list[k], ref list[i]);
				}
		}

		public static void TEST()
		{
			string str = "abcd";
			char[] arr = str.ToCharArray();
			GetPer(arr);
		}
	}
}
