using System;
using System.Collections.Generic;
using System.Text;

namespace DSAlgo
{
	class StackTest
	{


		//	https://www.tutorialsteacher.com/csharp/csharp-stack
		public static void Test()
		{ 
			Stack<int> stack = new Stack<int>();

			for (int i = 0; i < 10; i++)
			{
				stack.Push(i);
			}

			foreach (var s in stack)
			{
				Console.WriteLine(s);//會跟加入的順序反著印   類似pop的感覺
			}

			Console.WriteLine();

			Console.WriteLine(stack.Peek());
			Console.WriteLine(stack.Peek());

			int[] arr = new[] { 1, 2, 3, 4};
			Stack<int> stack2 = new Stack<int>();

			Console.WriteLine(stack.Contains(3));

			while (stack.Count > 0)
			{
				Console.WriteLine(stack.Pop());
				Console.WriteLine(stack.Count);
			}
			
		}

	}
}
